    internal class Program
    {
        private static void Main(string[] args)
        {
            var task = DoWork();
            Console.WriteLine("Task status: " + task.Status);
            Console.WriteLine("Waiting for ENTER");
            Console.ReadLine();
        }
        private static async Task DoWork()
        {
            Console.WriteLine("Entered DoWork(). Sleeping 3");
            // imitating time consuming code
            // in a real-world app this should be inside task, 
            // so method returns fast
            Thread.Sleep(3000);
            await Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("async task iteration " + i);
                        // imitating time consuming code
                        Thread.Sleep(1000);
                    }
                });
            
            Console.WriteLine("Exiting DoWork()");
        }
    }
