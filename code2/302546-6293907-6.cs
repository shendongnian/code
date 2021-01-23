    public IList<T> GetMany<TEntity, TProp>(
      Expression<Func<TEntity, TProp>> property,
      IEnumerable<TProp> values)
    {
        string propertyName = ((System.Linq.Expressions.MemberExpression)property.Body).Member.Name;
    
        List<T> loadedEntities = new List<T>();
    
        // only flush the session once. 
        session.Flush();
        var previousFlushMode = session.FlushMode;
        session.FlushMode = FlushMode.Never;
    
        for (int i = 0; i < knownIds; i += 1000)
        {
          var page = knownIds.Skip(i).Take(1000).ToArray();
          
          loadedEntities.AddRange(session
            .CreateCriteria(typeof(T))
            .Add(Restriction.PropertyIn(propertyName, page)
            .List<TEntity>();
        }
    
        session.FlushMode = previousFlushMode;
        return loadedEntities;
    }
