	public override void Amend(Method method)
	{
		method.Context<Stopwatch>()
			.Before((T instance, string method, object[] parameters)
				=> { var s = new Stopwatch(); s.Start(); return s; })
			.After((T instance, string method, Stopwatch stopwatch, object[] parameters)
				=> Console.WriteLine(method + ": " + stopwatch.ElapsedMilliseconds);
	}
