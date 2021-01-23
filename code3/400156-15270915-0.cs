    class SomeClass : IDisposable
    {
        bool _disposed = false;
        public void Dispose()
        {
            while (true && !_disposed)
            {
                _disposed = true;
                Console.WriteLine("disposed");
            }
        }
        ~SomeClass()
        {
            Dispose();
        }
    }
