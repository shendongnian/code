    async void Main()
    {
    	var lines = File.ReadAllLines("file.txt");
    	int i = 0;
    	var concurrency = 3;
    	while (i < lines.Length)
    	{
    		var tasks = new List<Task>(concurrency);
    		for (int j = 0; j < concurrency && i < lines.Length; j++)
    		{
    			tasks.Add(MyMethod(lines[i++]));
    		}
    		await Task.WhenAll(tasks);
    	}
    }
    public Task	MyMethod(string s)
    {
    	return Task.CompletedTask;
    }
