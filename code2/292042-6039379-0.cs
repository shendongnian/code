    class TestClass : IDisposable
    {
        public void GetTest()
        {
            throw new Exception("Something bad happened"); // handle this
        }
        public void Dispose()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (TestClass t = new TestClass())
                {
                    Thread ts = new Thread(new ThreadStart(t.GetTest));
                    ts.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
