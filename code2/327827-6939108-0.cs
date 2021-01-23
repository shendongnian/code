    using System;
    
    namespace toFixedExample
    {
        public static class MyExtensionMethods
        {
            public static string toFixed(this double number, uint decimals)
            {
                return number.ToString("N" + decimals);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                double d = 465.974;
                var a = d.toFixed(2);
                var b = d.toFixed(4);
                var c = d.toFixed(10);
            }
        }
    }
