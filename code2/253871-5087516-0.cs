    public static void PrintIfLookup(object obj)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
    
        var lookupType = obj
                        .GetType()
                        .GetInterfaces()
                        .FirstOrDefault
                         (i => i.IsGenericType &&
                               i.GetGenericTypeDefinition() == typeof(ILookup<,>));
    
        if (lookupType != null)
        {
            // It is an ILookup<,> 
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
    
            // Assuming the containing type is Foo
            typeof(Foo).GetMethod("PrintLookup", flags)
                       .MakeGenericMethod(lookupType.GetGenericArguments())
                       .Invoke(null, new[] { obj });
        }
                
    }
    
    private static void PrintLookup<TKey, TElement>(ILookup<TKey, TElement> lookup)
    {
        // TODO: Printing logic    
    }
