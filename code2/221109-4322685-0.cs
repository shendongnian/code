    using System;
    
    public class Program
    {
        static dynamic Min(dynamic a, dynamic b)
        {
            return Math.Min(a, b);        
        }
    
        static void Main(string[] args)
        {
            int i = Min(3, 4);
            double d = Min(3.0, 4.0);
        }
    }
