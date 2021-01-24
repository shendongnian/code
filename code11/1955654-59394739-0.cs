	var results = new int[3];
		
	var tasks = new[] {
		Task.Factory.StartNew(() => results[0] = GetSomething1()), 
		Task.Factory.StartNew(() => results[1] = GetSomething2()), 
		Task.Factory.StartNew(() => results[2] = GetSomething3())
	};
		
	await Task.WhenAll(tasks);
	
	Console.WriteLine(results[0]);
	Console.WriteLine(results[1]);
	Console.WriteLine(results[2]);
