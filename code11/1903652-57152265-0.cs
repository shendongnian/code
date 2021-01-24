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
            static void Main(string[] args)
            {
                try
                {
                    string s = "Mon Jul 15 2019 00:00:00 GMT +0300 ";
                    DateTime t;
                    DateTime.TryParseExact(s,
                           "ddd MMM dd yyyy h:mm:ss GMT +0300 ",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out t);
                }
                catch(Exception ex)
                {
                    //Log exception
                }
    
            }
        }
    }
