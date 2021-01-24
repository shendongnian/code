    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace ObjectDictionary
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                IDictionary <string, object>  dict= new Dictionary<String, object>();
                dict.Add("abc", new {value = "blah", sortOrder = 1});
    
                dynamic a = dict["abc"];
                Console.WriteLine(a.value);
                Console.WriteLine(a.sortOrder);
            }
        }
    }
