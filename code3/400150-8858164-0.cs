    using System;
    
    public class Test
    {    
        public static void Main()
        {
            double d = 0.1d;
            Console.WriteLine("d = " + DoubleConverter.ToExactString(d));
            d += 0.1d;
            Console.WriteLine("d = " + DoubleConverter.ToExactString(d));
            d += 0.1d;
            Console.WriteLine("d = " + DoubleConverter.ToExactString(d));
            d += 0.1d;
            Console.WriteLine("d = " + DoubleConverter.ToExactString(d));
            d += 0.1d;        
            Console.WriteLine("d = " + DoubleConverter.ToExactString(d));
        }
    }
