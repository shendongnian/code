    public List<Foo> GetFooFromBar(string bar)
    {
         return = typeof(FooContext)//a list of DbSets (DbSet<Foo>, DbSet<Bar>)
        .GetProperties()
        .Where(e => e.Name == bar)//Filter based on the name of DbSet entered
        .GetType()//Get Type of the object returned (the DbSet with a matching name)
        .GetGenericArguments()[0]//Get the first item in the array of PropertyInfo
        .GetProperties()//Get a list of the properties of the DbSet within the Context
        .ToList();
        return bar;
    }
