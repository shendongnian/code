    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            IList<string> list1 = new List<string>();
            IList<string> list2 = new List<string>();
    
            var type1 = list1.GetType();
            var type2 = list2.GetType();
    
            Console.WriteLine(type1.Equals(type2)); // Prints True
        }
    }
