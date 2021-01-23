    using System;
    using System.Linq;
    
    class Example
    {
        static void Main()
        {
            var first = Enumerable.Empty<Example>();
            var second = Enumerable.Empty<Example>();
    
            Console.WriteLine(object.ReferenceEquals(first, second));
        }
    }
