    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
        
        public static double result = 0;
        
        static double Multiply(double firstParam, double secondParam)
        {
            return result += firstParam * secondParam;
        }
        
        public static void Main(string[] args)
        {
            Multiply(2.5, 2);
            Multiply(6, 7);
            Console.WriteLine(result);
        }
    }
    }
