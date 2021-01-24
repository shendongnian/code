    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp24
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new aEntities())
                {
                    var result = db.Insert(0.0033M);
                    Console.WriteLine(result.First().Value);
                    Console.ReadKey();
                }
            }
        }
    }
