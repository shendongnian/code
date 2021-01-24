    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    Console.WriteLine("Calculations " + DateTime.Now);         
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
