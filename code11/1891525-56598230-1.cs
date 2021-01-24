    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace EvenOrOdd
    {
        class Program
        {
            static void Main(string[] args)
            {
                decimal num, sum = 0, r;
                Console.WriteLine("\nEnter a Number : ");
                num = int.Parse(Console.ReadLine());
                while (num >= 1)
                {
                    r = num % 10;
                    num = num / 10;
                    sum = sum + r;
                }
    
                Console.WriteLine("Sum of Digits of the Number : " + sum);
                Console.ReadLine();
            }
        }
    }
