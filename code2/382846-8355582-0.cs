    public static IQueryable<Person> QueryByExample(Person example, YourContext context)
    {
        var query = context.Persons;
        if (example.Name != null) 
        {
           string name = example.Name;
           query = query.Where(p => p.Name == name);
        }
        // Same for other properties
        return query;
    }
  
