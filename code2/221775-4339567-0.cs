    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Simple list.
                var list = new List<int> { 1, 2, 3, 4 };
    
                // Try it with first
                var result = DoItemSelect(list, Enumerable.First);
                Console.WriteLine(result);
    
                // Try it with last
                result = DoItemSelect(list, Enumerable.Last);
                Console.WriteLine(result);
    
                // Try it with ElementAt for the second item (index 1) in the list.
                result = DoItemSelect(list, enumerable => enumerable.ElementAt(1));
                Console.WriteLine(result);
            }
    
            public static T DoItemSelect<T>(IEnumerable<T> enumerable, Func<IEnumerable<T>, T> selector)
            {
                // You can do whatever you method does here, selector is the user specified func for
                // how to select from the enumerable.  Here I just return the result of selector directly.
                return selector(enumerable);
            }
        }
    }
