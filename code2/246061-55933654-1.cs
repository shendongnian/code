    class Program
    {
        static void Main(string[] args)
        {
            PeriodicTask
                .Run(GetSomething, TimeSpan.FromSeconds(3))
                .GetAwaiter()
                .GetResult();
        }
        static async Task GetSomething()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine($"Hi {DateTime.UtcNow}");
        }
    }
