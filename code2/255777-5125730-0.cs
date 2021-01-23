    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var dictionary = new Dictionary<int, Action<string>>
            {
                { 5, x => Console.WriteLine("Action for 5: {0}", x) },
                { 13, x => Console.WriteLine("Unlucky for some: {0}", x) }
            };
            
            dictionary[5]("Woot");
            dictionary[13]("Not really");
        }
    }
