    IEnumerable<Assembly> assemblies = ...
    Assembly assemblyA = ...
    // Since you say the only fact you wish to use about the class is that it
    // is named 'Customer' and it exists in Assembly A, this is just about the 
    // only way to construct the Type object. Pretty awful though...
    Type customerType = assemblyA.GetTypes() 
                                 .Single(t => t.Name == "Customer");    
    // From all the types in the chosen assemblies, find the ones that subclass 
    // Customer, picking the one with the deepest inheritance heirarchy.
    Type bottomCustomerType = assemblies.SelectMany(a => a.GetTypes())
                                        .Where(t => t.IsSubclassOf(customerType))
                                        .OrderByDescending(t => t.GetInheritanceDepth())
                                        .First();
     ...
    public static int GetInheritanceDepth(this Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
    
        int depth = 0;
        // Keep walking up the inheritance tree until there are no more base classes.
        while (type != null)
        {
            type = type.BaseType;
            depth++;
        }
        return depth;
    }
