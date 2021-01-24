    // Get classes as type
    var classes = AppDomain.CurrentDomain
                           .GetAssemblies()
                           .SelectMany(t => t.GetTypes())
                           .Where(t => 
                               t.IsClass && 
                               t.Namespace == "ConsoleApp1.Methods" && 
                               !t.IsNested)
                           .ToList();
    
    // flatten class properties types
    var properties = classes.SelectMany(
       x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance)
             .Select(y => y.PropertyType));
    
    // Filter class list based on property list, as type
    var results = classes.Where(x => !properties.Contains(x))
                         .Select(x => x.Name)
                         .ToList();
