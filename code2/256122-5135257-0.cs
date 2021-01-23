    class Test {
        private object locker = new object();
        public void Run() {
            lock (locker) {  // <== breakpoint here
                Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
 
