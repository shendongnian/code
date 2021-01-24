    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    namespace ConsoleApplication108
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                Random rand = new Random();
                int[] numbers = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    numbers[i] = rand.Next(1000, 10000);
                }
                string prefix = string.Join("-", numbers);
                for(int i = 0; i < 100; i++)
                {
                    int threeDigits = rand.Next(100, 1000);
                    int lastNumber = rand.Next(1000, 10000);
                    Console.WriteLine("{0}{1}:{2}", prefix,threeDigits, lastNumber);
                }
                Console.ReadLine();
                 
            }
        }
    }
