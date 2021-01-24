    using System;
    using System.Collections.Generic;
    using System.Text;
     
    namespace ConsoleApplication1
    {
        class Program
        {
     
            static int Fact(int n)
            {
                if (n <= 1)
                    return 1;
                return n * Fact(n - 1);
            }
     
            static int Factorial(int n)
            {
                if (n <= 1)
                    return 1;
                int result = 1;
                for (int i = 2; i <= n; i++)
                {
                    result = result * i;
                }
                return result;
            }
     
     
            static void Main(string[] args)
            {
                Console.Write("Enter a Number to find factorial: ");
                int n = Convert.ToInt32(Console.ReadLine());
                int r = Fact(n);
                Console.WriteLine(n.ToString() + "! = " + r.ToString());
     
                Console.Write("Enter a Number to find factorial: ");
                n = Convert.ToInt32(Console.ReadLine());
                r = Factorial(n);
                Console.WriteLine(n.ToString() + "! = " + r.ToString());           
            }
        }
    }
