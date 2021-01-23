    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random r = new Random();
    
                int sum=0;
                for (int i = 0; i < 4; i++)
                {
                    var roll = r.Next(1, 7);
                    sum += roll;
                }
                // sum should be the sum of the four dices
                Console.WriteLine("the sum of the first 4 throws is {0}", sum);
    
                if (sum > 20)
                {
                    Console.WriteLine("place your message in here stating that sum gas greater than 20");
                }
                else if (sum < 10)
                {
                    Console.WriteLine("sum is less than 10");
                }
                else
                {
                    Console.WriteLine("some other message");
                }
            }
        }
    }
