    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace GenConsole
    {
        class Program
        {    
            static void Main(string[] args)
            {
                CoalescingOp();
                Console.ReadKey();
            }
    
            static void CoalescingOp()
            {
                // A nullable int
                int? x = null;
                // Assign x to y.
                // y = x, unless x is null, in which case y = -33(an integer selected by our own choice)
                int y = x ?? -33;
                Console.WriteLine("When x = null, then y = " + y.ToString());
    
                x = 10;
                y = x ?? -33;
                Console.WriteLine("When x = 10, then y = " + y.ToString());    
            }
        }
    }
