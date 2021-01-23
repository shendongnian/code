    using System;
    
        class Program
        {
            static void Main(string[] args)
            {
                int num, i, j, k;
                Console.Write("enter the level:");
                num=Convert.ToInt32(Console.ReadLine());
                for (i = 1; i <= num; i++)
                {
                    for (j = 1; j < num-i+1; j++)
                    {
                        Console.Write(" ");
                    }
                    for (k = 1; k <= i; k++)
                    {
                        Console.Write(i);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
    
                }
            }
        }
        
