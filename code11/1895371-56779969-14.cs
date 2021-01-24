    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            //Your code goes here
            Dictionary<string,int> myDict = null;
    
            if (myDict?.Bar(out var test) == null)
            {               
                Console.WriteLine("does hit");
            }
        }
    }
    
    static class Foo
    {
        public static object Bar(this Dictionary<string,int> input, out int test)
        {
            test = 3;
            Console.WriteLine("does not hit");
            return 1;
        }
    }
