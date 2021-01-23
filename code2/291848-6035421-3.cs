	async void Main()
	{
		try
		{
			var cancelTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(1000));
			var foo = await GetFooAsync(cancelTokenSource.Token);
			Console.WriteLine(foo);
		}
		catch (OperationCanceledException e)
		{
			Console.WriteLine("Process took too long");
		}
	}
    private Random RandomProvider = new Random();
    
    public async Task<double> GetFooAsync(CancellationToken cancelToken) {
        double a = RandomProvider.Next(2, 5); 
        while (a == 3) 
		{ 
			cancelToken.ThrowIfCancellationRequested();
			RandomProvider.Next(2, 5);
		} 
        double b = RandomProvider.Next(2, 5); 
        double c = b /a; 
        double e = RandomProvider.Next(8, 11); 
        while (e == 9) 
		{ 
			cancelToken.ThrowIfCancellationRequested();
			RandomProvider.Next(8,11); 
		} 
        double f = b / e;
        return f;
    }
