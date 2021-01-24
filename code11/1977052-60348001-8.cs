	public static async Task Main()
	{
		Console.WriteLine("Hello World");
		await new Program().APIMethod();
	}
	public async Task APIMethod()
	{
		var cts = new CancellationTokenSource();
		var tasks = new[]{CheckThree(cts.Token), CheckTwo(cts.Token), CheckOne(cts.Token), CheckTwo(cts.Token), CheckThree(cts.Token)};
		//continue on first successful task, throw exception if all tasks fail
		await tasks.WhenFirst(result => result == CustomStatusCode.Success);
		cts.Cancel(); //cancel remaining tasks if any
		foreach (var t in tasks)
		{
			Console.WriteLine($"Id = {t.Id}, Result = {t.Result}");
		}
	}
