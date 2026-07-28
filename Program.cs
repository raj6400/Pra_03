using System;
using System.Collections.Generic;

namespace Pra_03
{
    class Expence
    {
        public int ExpenceID;
        public string Category;
        public double Amount;
        public string PaymentMode;
        public DateTime Date;

        public Expence(int expenceID, string category, double amount, string paymentMode, DateTime date)
        {
            ExpenceID = expenceID;
            Category = category;
            Amount = amount;
            PaymentMode = paymentMode;
            Date = date;
        }
    }

    class ExpenseManager
    {
        List<Expence> expenses = new List<Expence>();

        public void AddExpence()
        {
            Console.Write("Enter Expense ID: ");
            int expenceID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Payment Mode: ");
            string paymentMode = Console.ReadLine();

            Console.Write("Enter Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Expence exp = new Expence(expenceID, category, amount, paymentMode, date);

            expenses.Add(exp);

            Console.WriteLine("Expense Added Successfully.");
        }

        public void DisplayExpence()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No Expenses Found.");
                return;
            }

            Console.WriteLine("\n================ Expense List ================");
            Console.WriteLine("ID\tCategory\tAmount\tPayment Mode\tDate");

            foreach (Expence exp in expenses)
            {
                Console.WriteLine($"{exp.ExpenceID}\t{exp.Category}\t\t{exp.Amount}\t{exp.PaymentMode}\t\t{exp.Date.ToShortDateString()}");
            }
        }

        public void RemoveExpence()
        {
            Console.Write("Enter Expense ID to Remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Expence exp = expenses.Find(x => x.ExpenceID == id);

            if (exp != null)
            {
                expenses.Remove(exp);
                Console.WriteLine("Expense Removed Successfully.");
            }
            else
            {
                Console.WriteLine("Expense ID Not Found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager manager = new ExpenseManager();

            while (true)
            {
                Console.WriteLine("\n===== Expense Management System =====");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Display Expenses");
                Console.WriteLine("3. Remove Expense");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Your Choice: ");

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        manager.AddExpence();
                        break;

                    case 2:
                        manager.DisplayExpence();
                        break;

                    case 3:
                        manager.RemoveExpence();
                        break;

                    case 4:
                        Console.WriteLine("Thank You!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}
