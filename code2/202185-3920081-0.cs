    using System;
    using IComparer = System.Collections.IComparer;
    
    class CustomOrder: IComparer
    {
        static readonly int[]   positions = { 2, 1, 3, 0 };
    
        public int Compare( object x, object y )
        {
            return positions[(char)x-'a'].CompareTo( positions[(char)y-'a'] );
        }
    }
    
    class Startup
    {
        static void Main(string[] args)
        {
            char[]  collection  = {'a', 'b', 'c', 'd'};
    
            Console.WriteLine( collection );            // abcd
            Array.Sort( collection, new CustomOrder() );
            Console.WriteLine( collection );            // dbac
        }
    }
