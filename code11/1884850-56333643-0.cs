        static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Dictionary<string, string> Dict = new Dictionary<string, string>();
			Dictionary<string, string> Dict2 = new Dictionary<string, string>();
		
			foreach (var item in Dict)
			{
				if (Dict2.TryGetValue(item.Key, out string date))
				{
					var diffInSeconds = (DateTime.Parse(item.Value) - DateTime.Parse(date)).TotalSeconds;
					Console.WriteLine(diffInSeconds);
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
		}
