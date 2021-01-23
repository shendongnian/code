    var tasks = new List<IScheduledTask>();
    foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
    {
        if (t.IsSubclassOf(typeof(IScheduledTask)))
        {
            tasks.Add((IScheduledTask)Activator.CreateInstance(t));
        }
    } 
