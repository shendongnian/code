    using (var lifetime = container.BeginLifetimeScope())
    {
    	var calc = lifetime.Resolve<IContentService>();
    	var sum = calc.Add(a, b);
    	Console.WriteLine(sum);
    }
