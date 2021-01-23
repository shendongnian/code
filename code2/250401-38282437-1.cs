    using System;
    using System.Globalization;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                System.Globalization.CultureInfo.CurrentCulture = 
                    new CultureInfo("fa-IR");
                Console.WriteLine(System.DateTime.Now); 
                // Prints: 1395/4/19 A.D. 13:31:55  
            }
        }
    }
