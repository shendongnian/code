    class Program
    {
        public class MyTuple
        {
            private Tuple<int, int> t;
            public MyTuple(int a, int b)
            {
                t = new Tuple<int, int>(a, b);
            }
            public int A
            {
                get
                {
                    return t.Item1;
                }
            }
            public int B
            {
                get
                {
                    return t.Item2;
                }
            }
            public override bool Equals(object obj)
            {
                return t.Equals(((MyTuple)obj).t);
            }
            public override int GetHashCode()
            {
                return t.GetHashCode();
            }
            public static bool operator ==(MyTuple m1, MyTuple m2)
            {
                return m1.Equals(m2);
            }
            public static bool operator !=(MyTuple m1, MyTuple m2)
            {
                return !m1.Equals(m2);
            }
        }
        static void Main(string[] args)
        {
            var v1 = new MyTuple(1, 2);
            var v2 = new MyTuple(1, 2);
            Console.WriteLine(v1 == v2);
            Dictionary<MyTuple, int> d = new Dictionary<MyTuple, int>();
            d.Add(v1, 1);
            Console.WriteLine(d.ContainsKey(v2));
        }
    }
