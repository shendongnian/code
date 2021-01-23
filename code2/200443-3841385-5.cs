    using System;
    using System.Collections.Generic;
    using System.Linq;
    struct I<T>
    {
        public readonly T V;
        public I(T v)
        {
            V = v;
        }
    }
    class Obj
    {
        public int A { get; set; }
        public string B { get; set; }
        public override string ToString()
        {
            return string.Format("A={0}, B={1}", A, B);
        }
    }
    class Program
    {
        static void Main()
        {
            var list = new List<int> { 100 };
            new I<List<int>>(list)
                {
                    V = { 1, 2, 3, 4, 5, 6 }
                };
            Console.WriteLine(string.Join(" ", list.Select(x => x.ToString()).ToArray())); // 100 1 2 3 4 5 6 
            var obj = new Obj { A = 10, B = "!!!" };
            Console.WriteLine(obj); // A=10, B=!!!
            new I<Obj>(obj)
                {
                    V = { B = "Changed!" }
                };
            Console.WriteLine(obj); // A=10, B=Changed!
        }
    }
