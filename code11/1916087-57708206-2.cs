    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static int simpleArraySum(int[] ar)
        {
            int sum = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                sum = sum + ar[i];
            }
    
            return sum;
        }
    
        static void Main(string[] args)
        {
            Console.WriteLine(simpleArraySum(new int[] { 1, 2, 3 }));
        }
    }
