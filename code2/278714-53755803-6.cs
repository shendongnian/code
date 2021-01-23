    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ExampleConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Run();
            }
    
            public static void SomeMethod()
            {
                if(/*Some condition is met where you want to "re-start" the program*/)
                {
                    //do something first
    
                    //"re-start" the program by calling the Run() method
                    Run();
                }
            }
    
            public static void Run()
            {
                //stuff that used to be in the public method
                int MainMethodSomeNumber = 0;
                string MainMethodSomeString = default(string);
    
                SomeMethod();
                //etc.
            }
        }
    }
