    class Example
    {
        public char Value;
        public override int GetHashCode()
        {
            return 1;
        }
        public override bool Equals(object obj)
        {
            return obj is Example && ((Example)obj).Value == Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Example() { Value = 'a' };
            var e2 = new Example() { Value = 'b' };
            var map1 = new Dictionary<Example, string>();
            map1.Add(e1, "1");
            map1.Add(e2, "2");
            var map2 = new Dictionary<Example, string>();
            map2.Add(e2, "2");
            map2.Add(e1, "1");
            Console.WriteLine(map1.Values.Aggregate((x, y) => x + y));
            Console.WriteLine(map2.Values.Aggregate((x, y) => x + y));
        }
    }
