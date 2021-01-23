    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string mnthname = "january";
                int i = DateTime.ParseExact(mnthname, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                Console.WriteLine(i.ToString());
                Console.ReadLine();
            }
        }
    }
