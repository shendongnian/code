    public class Synchronization
    {
        private static object _lock = new object();
        public void MethodA()
        {
            lock (_lock)
            {
                Console.WriteLine("I shouldn't execute with MethodB");
            }
        }
        public void MethodB()
        {
            //This shouldn't be allowed!
            _lock = new object();
            lock (_lock)
            {
                Console.WriteLine("I shouldn't execute with MethodA");
            }
        }
    }
