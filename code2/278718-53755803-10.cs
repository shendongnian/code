    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ExampleConsole
    {
        class Program
        {
            public static List<string> MainMethodArgs = new List<string>();
            static void Main(string[] args)
            {
                MainMethodArgs = args.ToList();
                Run(MainMethodArgs.ToArray());
            }
    
            public static void SomeMethod()
            {
                if(/*Some condition is met where you want to "re-start" the program*/)
                {
                    //do something first
    
                    //"re-start" the program by calling the Run() method
                    Run(MainMethodArgs.ToArray());
                }
            }
    
            public static void Run(string args[])
            {
                //stuff that used to be in the public method
                int MainMethodSomeNumber = 0;
                string MainMethodSomeString = default(string);
    
                SomeMethod();
                //etc.
            }
        }
    }
