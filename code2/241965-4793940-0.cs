    using System;
    
    class Test
    {
        static void Main()
        {
            StringComparer comparer = StringComparer.InvariantCultureIgnoreCase;
            Console.WriteLine(comparer.Compare("a", "A"));
            Console.WriteLine(comparer.Compare("a", null));
            Console.WriteLine(comparer.Compare(null, "A"));
        }
    }
