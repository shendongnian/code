    using System;
    using System.Collections.Generic;
     
    public class Test
    {
        public static void Main()
        {
            List<int> l = new List<int>() { 1, 2, 3 };
            Fuss(l);
            Console.WriteLine(l.Count); // Count will now be 5.
     
            FussNonRef(l);
            Console.WriteLine(l.Count); // Count will still be 5 because we 
                                        // overwrote the copy of our reference 
                                        // in FussNonRef.
     
            FussRef(ref l);
            Console.WriteLine(l.Count); // Count will be 2 because we changed
                                        // our reference in FussRef.
        }
     
        private static void Fuss(List<int> l)
        {
            l.Add(4);
            l.Add(5);
        }
     
        private static void FussNonRef(List<int> l)
        {
            l = new List<int>();
            l.Add(6);
            l.Add(7);
        }
     
        private static void FussRef(ref List<int> l)
        {
            l = new List<int>();
            l.Add(8);
            l.Add(9);
        }
    }
