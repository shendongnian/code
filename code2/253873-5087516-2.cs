    public static void PrintIfLookup(object obj)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
    
        // Find first implemented interface that is a constructed version of
        // ILookup<,>, or null if no such interface exists.
        var lookupType = obj
                        .GetType()
                        .GetInterfaces()
                        .FirstOrDefault
                         (i => i.IsGenericType &&
                               i.GetGenericTypeDefinition() == typeof(ILookup<,>));
    
        if (lookupType != null)
        {
            // It is an ILookup<,>. Invoke the PrintLookup method
            // with the correct type-arguments.
            // Method to invoke is private and static.
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
    
            // Assuming the containing type is called Foo.
            typeof(Foo).GetMethod("PrintLookup", flags)
                       .MakeGenericMethod(lookupType.GetGenericArguments())
                       .Invoke(null, new[] { obj });
        }
                
    }
    
    private static void PrintLookup<TKey, TElement>(ILookup<TKey, TElement> lookup)
    {
        // TODO: Printing logic    
    }
