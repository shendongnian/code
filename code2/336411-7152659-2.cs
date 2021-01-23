        // TODO proper caching
        // TODO proper random generation
	var randomType = Assembly.GetAssembly(typeof(MainClass))
		.GetTypes()
		.Where(t => typeof(B).IsAssignableFrom(t))
		.Where(t => !(t.IsAbstract || t.IsInterface))
		.Except(new [] { typeof(PowerupBase) })
		.OrderBy (t => new Random(DateTime.Now.Millisecond).Next())
                .First();
	
	Activator.CreateInstance(x);
