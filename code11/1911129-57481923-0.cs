    static async Task DatabaseCallsAsync()
    {
    	// List of input parameters
    	List<int> inputParameters = new List<int> {1,2,3,4,5};	
    	await Task.WhenAll(inputParameters.Select(x => DatabaseCallAsync($"Task {x}")));
    }
    
    static async Task DatabaseCallAsync(string taskName)
    {
    	Console.WriteLine($"{taskName}: start");
    	await Task.Delay(3000);
    	Console.WriteLine($"{taskName}: finish");
    }
