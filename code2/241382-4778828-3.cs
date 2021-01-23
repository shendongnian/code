    public DbCommand RecycledParameters(string sql, IList<DbParameter> parameters)
    {
        var result = db.GetSqlStringCommand(sql);
        foreach(DbParameter p in parameters)
        {  
            db.AddInParameter(result, p.ParameterName, p.DbType, p.Value);
        }
        return result;
    }
