    using System.IO;
    using System;
    using Mehroz;
    
    class Program
    {
        static void Main()
        {
            double d = .5;
            string str = new Fraction(d).ToString();
            
            Console.WriteLine(str);
        }
    }
