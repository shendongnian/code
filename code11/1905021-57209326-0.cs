    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var input = "25-JUL-19 03.22.05.0360000 PM";
    
                var output = DateTime.ParseExact(input, "dd-MMM-yy hh.mm.ss.fffffff tt", CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
        }
        
    }
