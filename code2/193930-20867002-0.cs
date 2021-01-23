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
                double n, x;
                int a, dec = 0;
                Console.WriteLine("Enter double");
                n = Convert.ToDouble(Console.ReadLine());
               
                a = Convert.ToInt32(n);
                x = n - a;
                if (x < 0)
                    a--;
                int k = 1000;
                for (int i = 0; i < n.ToString().Length; i++)
                {
                    if (n.ToString()[i] == '.')
                        k = i;
                    if (i > k)
                        dec = dec * 10 + (n.ToString()[i]-48);
                }
               
                Console.WriteLine("Non-fraction " + a);
                Console.WriteLine("Fraction " + dec);
             
    
                Console.ReadKey();
                
            }
           
            
        }
    }
