    IEnumerable<Assembly> assemblies = ...
    
    var bottomCustomerType = assemblies.SelectMany(a => a.GetTypes())
                                       .Where(t => t.IsSubclassOf(typeof(Customer)))
                                       .OrderByDescending(t => t.GetInheritanceDepth())
                                       .First();
     ...
    public static int GetInheritanceDepth(this Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
    
        int depth = 0;
        while (type != null)
        {
            type = type.BaseType;
            depth++;
        }
        return depth;
    }
