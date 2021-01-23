    public IEnumerable<MyType> DoSomething(params Expression<Func<MyType,object>>[] properties)
     {
         var query = // create LINQ query that returns IQueryable<MyType>
         query = query.OrderBy(properties.First());
    
         foreach (var property in properties.Skip(1))
         {
             query = query.ThenBy(property);
         }
     }
    
     …
    
     var results = DoSomething(() => x.Age, () => x.Height, () => x.LastName);
