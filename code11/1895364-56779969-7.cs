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
    
            if (myDict?.TryGetValue("hello", out var value) == null)
            {               
                Console.WriteLine("Hello" + value.ToString());
            }
        }
    }
