    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                double km,m,f,i,cm;
    
                Console.WriteLine("The distance between karachi and lahore in (kilometer)km is=");
                km = Convert.ToInt32(Console.ReadLine());
    
                m = km * 1000;
                Console.WriteLine("The distance between karachi and lahore in meter(m) is="+m);
    
                f = km * 3280.84;
                Console.WriteLine("The distance between karachi and lahore in feet(f) is="+f);
    
                i = km * 39370.1;
                Console.WriteLine("The distance between karachi and lahore in inches(i) is="+i);
    
                cm = m * 100;
                Console.WriteLine("The distance between karachi and lahore in centimeter(cm) is="+cm);
    
                Console.ReadLine();
            }
        }
    }
      
