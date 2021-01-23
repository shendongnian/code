    public void Update(Action<T> updateStatement, Expression<Func<T, bool>> where)
    {
        // get your object context & objectset, cast to IQueryable<T>
        var table = (IQueryable<T>)objectContext.CreateObjectSet<T>();        
        // filter with the Expression
        var items = table.Where(where);
    
        // perform the Action on each item
        foreach (var item in items)
        {
            updateStatement(item);
        }
    
        objectContext.SubmitChanges();
    }
