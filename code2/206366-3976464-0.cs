    class Program
    {
        static void Main(string[] args)
        {
            using (new TestClass())
            {
                Console.WriteLine("In using");
            }
        }
        class TestClass : IDisposable
        {
            public TestClass()
            {
                throw new Exception();
            }
            public void Dispose()
            {
                Console.WriteLine("Disposed");
            }
        }
    }
