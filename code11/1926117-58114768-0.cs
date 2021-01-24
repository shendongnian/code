    using System;
    
    namespace test___login {
        class Program
        {
            static void Main(string[] args)
            {
                string location = "homepage";
                while (!location.ToUpper().Equals("EXIT"))
                {
                    while (location.Equals("Homepage", StringComparison.InvariantCultureIgnoreCase))
    
                    {
                        Console.WriteLine("homepage");
                        Console.WriteLine("WHere to now: ");
                        location = Console.ReadLine();
                    }
                    while (location.Equals("login", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("login");
                        Console.WriteLine("Where to now: ");
                        location = Console.ReadLine();
                    }
                }
            }
        }
    }
