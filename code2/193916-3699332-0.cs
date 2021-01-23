    using System;
    
    namespace stackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int Score1;
                int Score2;
                int Score3;
    
                Console.Write("Enter your score (out of 200 possible) on the first test: ");
                Score1 = int.Parse(Console.ReadLine());
                Console.Write("Enter your score (out of 200 possible) on the second test: ");
                Score2 = int.Parse(Console.ReadLine());
                Console.Write("Enter your score (out of 200 possible on the third test: ");
                Score3 = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                var percent = ((Score1 + Score2 + Score3) / 6D);
                Console.WriteLine("Your percentage to date is: {0:00.0}", percent);
                Console.ReadLine();
    
            }
        } 
    
    }
