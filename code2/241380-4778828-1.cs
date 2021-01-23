    public DbCommand RecycledParameters(string sql, IList<SomeCustomDbParameterType> parameters)
    {
        var result = new DbCommand(sql);
        foreach(SomeCustomDbParameterType p in parameters)
        {  
            db.AddInParameter(result, p.VariableName, p.Type, p.Value);
        }
        return result;
    }
