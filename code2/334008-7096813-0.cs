    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication32
    {
        class Program
        {
            static void Main(string[] args)
            {
                // setup a test string
                string stringToProcess = "Test";
                
                // actual solution here
                string result = String.Concat(stringToProcess.Select(c => c + ","));
                 
                // results: T,e,s,t,
                Console.WriteLine(result);
            }
        }
    }
