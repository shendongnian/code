    class A : IDisposable
    {
        // class members
        public void Dispose()
        {
            // free unmanaged resources
            // free managed resources
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var someInstance = new A())
            {
                // do some things with the class.
                // once the using block completes, Dispose
                // someInstance.Dispose() will automatically
                // be called
            }
        }
    }
