    var mscorlib = typeof(string).Assembly.GetTypes()
       .Where(t => string.IsNullOrEmpty(t.Namespace)).ToList();
    var system = typeof(Uri).Assembly.GetTypes()
       .Where(t => string.IsNullOrEmpty(t.Namespace)).ToList();
            
