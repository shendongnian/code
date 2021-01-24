    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting");
            DatabaseCallsAsync().Wait();            
            Console.WriteLine("ending"); // Must not fire until all database calls are complete.
            Console.Read();
        }
        static async Task DatabaseCallsAsync()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                tasks.Add(DatabaseCallAsync($"Task {i}"));
            }
            await Task.WhenAll(tasks.ToArray());
        }
        static async Task DatabaseCallAsync(string taskName)
        {
            Console.WriteLine($"{taskName}: start");
            await Task.Delay(3000);
            Console.WriteLine($"{taskName}: finish");
        }
    }
