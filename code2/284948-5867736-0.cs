    var query =
        from type in typeof(FrameworkElement).Assembly.GetTypes()
        where type.IsSubclassOf(typeof(FrameworkElement))
        select t.Name;
    
    List<string> controls = query.ToList();
