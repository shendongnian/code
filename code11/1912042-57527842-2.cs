        static async Task DatabaseCallsAsync()
        {
            List<Task> inputParameters = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                inputParameters.Add(DatabaseCallAsync($"Task {i}"));
            }
            await Task.WhenAll(inputParameters);
        }
