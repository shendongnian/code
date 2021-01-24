    var program = new Program();
	Mapper.CreateMap<Customer, CustomerViewItem>();
	Stopwatch watch = new Stopwatch();
	for (int x = 1; x <= 100000; x *= 10)
	{
		program.PopulateCustomers(x);
		watch.Start();
		program.RunMapper(x);
		watch.Stop();
		Console.WriteLine(string.Format("INITIAL :AutoMapper with {0}: {1}", x, watch.ElapsedMilliseconds));
		watch.Reset();
		program.PopulateCustomers(x);
		watch.Start();
		program.RunMapper(x);
		watch.Stop();
		Console.WriteLine(string.Format("AutoMapper with {0}: {1}", x, watch.ElapsedMilliseconds));
		watch.Reset();
		watch.Start();
		program.RunManual(x);
		watch.Stop();
		Console.WriteLine(string.Format("Manual Map with {0}: {1}", x, watch.ElapsedMilliseconds));
	}
	Console.ReadLine();
