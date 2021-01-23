    private static void ShowMeAll<TClass>(IEnumerable<TClass> items, string property )
    {
        // 1. Discover property type ONCE using reflection
        // 2. Create a dynamic method to access the property in a strongly typed fashion
        // 3. Cache the dynamic method for later use
    
        // here, my dynamic method is called dynamicPropertyGetter
        IEnumerable<TClass> sortedItems = items.OrderBy( o => dynamicPropertyGetter( o ) );
    }
