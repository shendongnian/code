	var obs = Observable.Range(1, 3);
		
	var query =
		from n in obs
		from s in obs.Sum()
		select new
		{
			Number = n.ToString(),
			Sum = s.ToString(),
		};
	using (var subscription = query.SubscribeOn(Scheduler.NewThread).Subscribe(
		x =>
			{
				Console.WriteLine(x.Number);
				Console.WriteLine(x.Sum);
			},
		err =>
			Console.WriteLine("Error"),
		() =>
			Console.WriteLine("Sequence Completed")))
	{
		Console.ReadLine();
	}
