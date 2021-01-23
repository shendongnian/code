    class Program
    {
        static void Main(string[] args)
        {
            using (MultiplyTask task = new MultiplyTask() { Multiplicands = new int[] { 2, 3 } })
            {
                WaitCallback cb = new WaitCallback(delegate(object x)
                {
                    MultiplyTask theTask = x as MultiplyTask;
                    theTask.Result = theTask.Multiplicands[0] * theTask.Multiplicands[1];
                    theTask.Set();
                });
                ThreadPool.QueueUserWorkItem(cb, task);
    
                Console.WriteLine("Calculating...");
                if (task.WaitOne(1000))
                {
                    Console.WriteLine("{0} times {1} equals {2}", task.Multiplicands[0], task.Multiplicands[1], task.Result);
                }
                else
                {
                    Console.WriteLine("Timed out waiting for multiplication task to finish");
                }
            }
        }
    
        private class MultiplyTask : EventWaitHandle
        {
            internal MultiplyTask() : base(false, EventResetMode.ManualReset) { }
            public int[] Multiplicands;
            public int Result;
        }
    }
