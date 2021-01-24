    var classes = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(t => t.GetTypes())
                           .Where(t => 
                                     t.IsClass && 
                                     t.Namespace == "ConsoleApp1.Methods" && 
                                     !t.IsNested)
                           .ToList();
    
    var properties = classes.SelectMany(
       x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance)
             .Select(y => y.PropertyType));
    
    var results = classes.Where(x => !properties.Contains(x))
                         .Select(x => x.Name);
    
    foreach (var result in results)
       Console.WriteLine(result);
