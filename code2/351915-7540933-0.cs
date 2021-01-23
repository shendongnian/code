    using System;
    
    namespace FirstProgram
    {
        class Program
        {
            static string userChoice;
            static int numbeR;
    
            static void Main()
            {
                Console.WriteLine("Write a number...");
                userChoice = Console.ReadLine();
    
                numbeR = Convert.ToInt32(userChoice);
                Console.WriteLine("You wrote {0}", numbeR);
                Console.ReadLine();
            }
        }
    }
