	Func<Task> battleFactory = async() => 
    {
		var sw = Stopwatch.StartNew();
		for ( var i = 1; i <= 3; i++ )
		{
			await Task.Delay(1000);
			Console.WriteLine( "{0}: In battle {1}", sw.Elapsed, i );
		}
	};
	Task battle = battleFactory();
	battle.Wait();
