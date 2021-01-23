    The best and easiest way of using a c++ dll file in c# :-
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    
    namespace demo1
    {
        class Program
        {
            [DllImport("shi.dll", EntryPoint = "?HelloWorld@@YAXXZ")]
           public static extern int HelloWorld();
          public  static void Main(string[] args)
            {
                //Console.WriteLine(StringUtilities.HelloWorld());
                Console.WriteLine(HelloWorld());
                // public static extern void HelloWorld();
               //  HelloWorld();
                //  Console.ReadKey();
            }
        }
    }
