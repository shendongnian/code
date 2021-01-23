    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> list = new List<MyClass>();
            list.Add(new MyClass() { Value = 2 });
            IEnumerable<MyClass> iterator = list.Where(x => x.Value == 3); // empty iterator.
            int max = iterator.Max(x => x.Value); // throws System.InvalidOperationException
        }
    }
    class MyClass
    {
        public int Value;
    }
    
