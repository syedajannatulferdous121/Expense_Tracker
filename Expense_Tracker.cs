using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    class Program
    {
        static List<Expense> expenses = new List<Expense>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Expense Tracker Application");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Last Expense");
                Console.WriteLine("3. View Monthly Expense");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddExpense();
                        break;
                    case 2:
                        ViewLastExpense();
                        break;
                    case 3:
                        ViewMonthlyExpense();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddExpense()
        {
            Console.WriteLine("Enter expense details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Amount: ");
            double amount = double.Parse(Console.ReadLine());
            Console.Write("Date (dd/mm/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            expenses.Add(new Expense(name, amount, date));
            Console.WriteLine("Expense added successfully!");
        }

        static void ViewLastExpense()
        {
            if (expenses.Count > 0)
            {
                Expense lastExpense = expenses[expenses.Count - 1];
                Console.WriteLine("Last Expense:");
                Console.WriteLine($"Name: {lastExpense.Name}");
                Console.WriteLine($"Amount: {lastExpense.Amount}");
                Console.WriteLine($"Date: {lastExpense.Date.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("No expenses found.");
            }
        }

        static void ViewMonthlyExpense()
        {
            Console.Write("Enter month (mm/yyyy): ");
            DateTime month = DateTime.ParseExact(Console.ReadLine(), "MM/yyyy", null);

            double totalExpense = 0;
            foreach (Expense expense in expenses)
            {
                if (expense.Date.Month == month.Month && expense.Date.Year == month.Year)
                {
                    totalExpense += expense.Amount;
                }
            }

            Console.WriteLine($"Total Expense for {month.ToString("MMMM yyyy")}: {totalExpense}");
        }
    }

    class Expense
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Expense(string name, double amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            Date = date;
        }
    }
}
