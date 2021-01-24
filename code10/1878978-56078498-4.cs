    class Program
    {
        // Specify C# 7.1 in the project's Properties.Build.Advanced.Language Version field
        // in order to use 'static async Task Main'
        static async Task Main(string[] args) // <--- Note the async Task
        {
            Console.WriteLine("Sleeping for 3 seconds");
            // the await prevents the app from exiting prematurely
            await Task.Delay(TimeSpan.FromSeconds(3));  
        }
    }
