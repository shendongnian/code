    // add any assemblies you want to discover scripts in here
    var assemblies = new[] { System.Reflection.Assembly.GetExecutingAssembly() }; 
    
    var scriptTypes = assemblies
        // get the declared types for each and every assembly
        .SelectMany(a => a.GetTypes())
        // filter so that we ignore BaseClass, only accept types assignable to base class,
        // don't accept abstract classes and only accept types with a parameterless constructor
        .Where(t => t != typeof(BaseClass) && typeof(BaseClass).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructors().Any(c => c.GetParameters().Length == 0));
    // create an instance of each type and construct a list from it
    var scripts = scriptTypes
        .Select(t => (BaseClass)Activator.CreateInstance(t))
        .ToList();
