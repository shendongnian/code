	// non blocking .net 4.5
	// ---------------------------
	
	Task.Run(()=> {
		await new WebClient().DownloadStringAsync(...any url on ur website);
		await Task.Delay(1000);
		_pc = new PerformanceCounter();
		pc.CategoryName = @"W3SVC_W3WP";
		pc.InstanceName = @"_Total";
		pc.CounterName = @"Requests / Sec";
		Console.WriteLine(pc.NextValue());
	});
	// blocking .net 4 and earlier
	// ---------------------------
	new WebClient().DownloadString(...any url on ur website);
	Thread.Sleep(1000);
	_pc = new PerformanceCounter();
	pc.CategoryName = @"W3SVC_W3WP";
	pc.InstanceName = @"_Total";
	pc.CounterName = @"Requests / Sec";
	Console.WriteLine(pc.NextValue());
