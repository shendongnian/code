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
                Func<dynamic, dynamic, dynamic> True = (a, b) => a;
                Func<dynamic, dynamic, dynamic> False = (a, b) => b;
    
                Func<Func<dynamic, dynamic, dynamic>, 
                     Func<dynamic, dynamic, dynamic>,
                     Func<dynamic, dynamic, dynamic> > And 
                    = (x, y) => x(y(True, False), False);
            }
        }
    }
