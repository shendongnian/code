    var currentAssembly = typeof(Program).Assembly;
    
    var currentAssemblyName = typeof(Program).Assembly.GetName().Name;
    
    var types = currentAssembly.GetTypes();
    
    var classes = types.Where(type => type.IsClass && !type.IsNested).ToList();
    
    var referencedTypes = classes.SelectMany(c => c.GetProperties().SelectMany(p => GetReferencedTypes(p.PropertyType))).Where(type => type.Assembly.GetName().Name == currentAssemblyName).Select(type => type.Name)
    	.Distinct().ToList();
