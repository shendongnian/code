    protected void Update<T>(object values, Expression<Func<T, bool>> where) where T : class
    {
        Domain.ExecuteStoreCommand(
            "UPDATE {0} SET {1} WHERE {2};",
            GetTableString<T>(),
            GetUpdateClauseString(values),
            GetWhereClauseString(where)
            );
    }
    protected string GetUpdateClauseString(object obj)
    {
        string update = "";
        var items = obj.ToDictionary();
        foreach (var item in items)
        {
            //Null
            if (item.Value is DBNull) update += string.Format("{0} = NULL", GetFieldString(item.Key));
            
            //Increment
            else if (item.Value is IncrementExpression) update += string.Format("{0} = {0} + {1}", GetFieldString(item.Key), ((IncrementExpression)item.Value).Value.ToString());
            
            //Decrement
            else if (item.Value is DecrementExpression) update += string.Format("{0} = {0} - {1}", GetFieldString(item.Key), ((DecrementExpression)item.Value).Value.ToString());
            
            //Set value
            else update += string.Format("{0} = {1}", GetFieldString(item.Key), GetValueString(item.Value));
            
            if (item.Key != items.Last().Key) update += ", ";
        }
        return update;
    }
    
    protected string GetWhereClauseString<T>(Expression<Func<T, bool>> where) where T : class
    {
        //Get query
        var query = ((IQueryable<T>)Domain.CreateObjectSet<T>());
        query = query.Where(where);
        ObjectQuery queryObj = (ObjectQuery)query;
        
        //Parse where clause
        string queryStr = queryObj.ToTraceString();
        string whereStr = queryStr.Remove(0, queryStr.IndexOf("WHERE") + 5);
        
        //Replace params
        foreach (ObjectParameter param in queryObj.Parameters)
        {
            whereStr = whereStr.Replace(":" + param.Name, GetValueString(param.Value));
        }
        
        //Replace schema name
        return whereStr.Replace("\"Extent1\"", "\"Primary\"");
    }
