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
            // You can add later easily too
            dictionary.Add(10, x => Console.WriteLine("Ten {0}", x));
            dictionary[15] = x => Console.WriteLine("Fifteen {0}", x);
            // Method group conversions work too
            dictionary.Add(0, MethodTakingString);
        }
        static void MethodTakingString(string x)
        {
        }
    }
