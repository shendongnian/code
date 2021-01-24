    public void DoWithFilters(Action action)
    {
        var current = Current;
		
        var managers = new List<UnitOfWorkManager>();
        foreach (var attribute in
                    new StackTrace().GetFrame(1).GetMethod().GetCustomAttributes(false).OfType<DisableFilterAttribute>())
            managers.Add(Current = Current.DisableFilter(attribute.DataFilter));
			
        action();
		
        managers.Reverse();
        foreach (var manager in managers)
            manager.Dispose();
			
        Current = current;
    }
