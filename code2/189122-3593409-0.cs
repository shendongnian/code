    class Program
    {
        public event Action<Program> SomeEvent;
        static void Main(string[] args)
        {
            var test = typeof(Program).GetMembers().First((mi) => mi.Name == "SomeEvent");
            Console.WriteLine(test.GetType());
        }
    }
