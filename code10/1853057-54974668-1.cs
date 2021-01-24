    private static readonly List<TopicGenerator> generators = 
        Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x.ImplementedInterfaces.Contains(typeof(TopicGenerator)))
            .Select(x => (TopicGenerator)Activator.CreateInstance(x))
            .ToList();
