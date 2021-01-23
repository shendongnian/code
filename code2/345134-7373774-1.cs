    using System;
    using System.Collections.Generic;
    static class Program
    {
        class MyComparer : Comparer<int>
        {
            public override int Compare(int x, int y)
            {
                Console.WriteLine("Compare(" + x + ", " + y + ")");
                if (x < y) return -1;
                if (x > y) return 1;
                return 0;
            }
        }
        static void Main()
        {
            MyComparer comparer = new MyComparer();
            List<int> list = new List<int> { 1, 2, 3 };
            list.Sort(comparer);
            return;
        }
    }
