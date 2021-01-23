    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace TestApp
    {
        class Program
    {
        static void Main()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Test(name.ToLower());
            Console.ReadLine();
        }
        static void Test(string name)
        {
            bool exit = true;
            string answer = "";
            do
            {
                switch (name)
                {
                    case "name":
                        Console.WriteLine("Hello Name");
                        break;
                    case "name2":
                        Console.WriteLine("Hello Name2");
                        break;
                }
                Console.WriteLine("Would you like to enter a new name? y/n: ");
                answer = Console.ReadLine();   // you're missing this line in your code.
                if (answer == "y")
                    exit = false;
                else
                    exit = true;
            }
            while (exit == false);
        }
    }
}
