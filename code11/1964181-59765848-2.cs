    class Program
    {
        private static Object _locker = new Object();
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    lock (_locker)
                    {
                        Console.WriteLine("Calculations " + DateTime.Now);
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
