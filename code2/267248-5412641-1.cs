    using System;
    using System.Collections.Generic;
    using System.Linq;
 
    public class Test
    {
        public static void Main()
        {
            List<int?> l = new List<int?>() {1, null, 2};
            Console.WriteLine(l.Min());
        }
    }
