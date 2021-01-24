    if (Database.IsInMemory())
    {
       // In memory test query type mappings
        modelBuilder.Query<MyQueryType>().ToQuery(() => LINQ_query);
        // ... similar for other query types
    }
    else
    {
        // Database query type mappings
        modelBuilder.Query<MyQueryType>().ToView("MyQueryTypeView");
        // ... 
    }
