	public static async Task Main(string[] args) {
		Console.WriteLine("Hello");
		var task1 = Task.Run(async () => {
			await Task.Delay(2000);
			Console.WriteLine("Fire");
		});
		var task2 = Task.Delay(5000);
		await Task.WhenAll(task1, task2);
		Console.WriteLine("Exit");
	}
