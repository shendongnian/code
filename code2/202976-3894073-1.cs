    using System;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                // FR Canadian
                Console.WriteLine("Displaying for: fr-CA");
                DisplayDatesForCulture("fr-CA");
    
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                
                // FR French
                Console.WriteLine("Displaying for: fr-FR");
                DisplayDatesForCulture("fr-FR"); 
    
                Console.WriteLine();
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
    
            static void DisplayDatesForCulture(string culture)
            {
                var ci = CultureInfo.GetCultureInfo(culture);
                var dt = new DateTime(2010, 10, 8, 18, 0, 0);
                
                foreach (string s in ci.DateTimeFormat.GetAllDateTimePatterns())
                    Console.WriteLine(dt.ToString(s));
            }
        }
    }
