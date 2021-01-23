    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ExampleConsole
    {
        class Program
        {
            public static List<string> MainMethodArgs = new List<string>();
            static void Main(string[] args)
            {
                MainMethodArgs = args.ToList();
                Run(MainMethodArgs.ToArray());
            }
    
            public static void Run(string[] args)
            {
                Console.WriteLine("Run() is starting");
                Console.ReadLine();
                //stuff that used to be in the public method
                int MainMethodSomeNumber = 0;
                string MainMethodSomeString = default(string);
    
                SomeMethod();
                //etc.
            }
    
            public static void SomeMethod()
            {
                Console.WriteLine("Rebuild Log Files"
                + " Press Enter to finish, or R to restar the program...");
                string restar = Console.ReadLine();
                if (restar.ToUpper() == "R")
                {
                    //here the code to restart the console...
                    Run(MainMethodArgs.ToArray());
                }
            }
        }
    }
