        static async Task DatabaseCallsAsync()
        {
            List<Task> inputParameters = new List<Task>();
            Parallel.For(0, 100, (i) => inputParameters.Add(DatabaseCallAsync($"Task {i}")));
            await Task.WhenAll(inputParameters);
        }
        static async Task DatabaseCallAsync(string taskName)
        {
            Console.WriteLine($"{taskName}: start");
            await Task.Delay(50);
            Console.WriteLine($"{taskName}: finish");
        }
