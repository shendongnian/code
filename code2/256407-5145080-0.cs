    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^\(.*,.*\)$");
            
            Console.WriteLine(regex.IsMatch("x(a,b)")); // False due to the x
            Console.WriteLine(regex.IsMatch("(a,b)x")); // False due to the x
            Console.WriteLine(regex.IsMatch("(ab)"));   // False due to the lack of ,
            Console.WriteLine(regex.IsMatch("(a,b"));   // False due to the lack of )
            Console.WriteLine(regex.IsMatch("(a,b)"));   // True!
            Console.WriteLine(regex.IsMatch("(aaa,bbb)"));   // True!
            Console.WriteLine(regex.IsMatch("(,)"));   // True!
        }
    }
