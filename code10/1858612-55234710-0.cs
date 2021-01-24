	void Main()
	{
		var query =
			from n in Observable.Range(0, 25)
			from v in Observable.FromAsync(() => GetValueAsync())
			select v;
			
		query.Take(1).Subscribe(x => Console.WriteLine(x));
	}
	
	private Random _random = new Random();
	
	public async Task<int> GetValueAsync()
	{
		var value = _random.Next(5, 100);
		Console.WriteLine($"!{value}");
		await Task.Delay(TimeSpan.FromSeconds(value));
		return value;
	}
