    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> list = new List<MyClass>();
            list.Add(new MyClass() { Value = 2 });
            int max = list.Where(x => x.Value == 3).Max(x => x.Value); // throws System.InvalidOperationException
        }
    }
    class MyClass
    {
        public int Value;
    }
    
