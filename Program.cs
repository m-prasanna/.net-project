using System;
using System.Collections.Generic;

namespace MyFirstApp
{
    class Program
    {
        // List to store our tasks
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("   Welcome to Task Manager!      ");
            Console.WriteLine("=================================\n");

            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("\nGoodbye! Thanks for using Task Manager!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Please try again.\n");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Delete a task");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice (1-4): ");
        }

        static void AddTask()
        {
            Console.Write("\nEnter your task: ");
            string task = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine($"\n✓ Task added successfully! You now have {tasks.Count} task(s).\n");
            }
            else
            {
                Console.WriteLine("\n✗ Task cannot be empty!\n");
            }
        }

        static void ViewTasks()
        {
            Console.WriteLine("\n--- Your Tasks ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet! Add one to get started.\n");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
                Console.WriteLine();
            }
        }

        static void DeleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks to delete!\n");
                return;
            }

            ViewTasks();
            Console.Write("Enter task number to delete: ");

            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= tasks.Count)
                {
                    string removedTask = tasks[taskNumber - 1];
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine($"\n✓ Deleted: {removedTask}\n");
                }
                else
                {
                    Console.WriteLine("\n✗ Invalid task number!\n");
                }
            }
            else
            {
                Console.WriteLine("\n✗ Please enter a valid number!\n");
            }
        }
    }
}