    public DbCommand RecycledParameters(string sql)
    {
        var result = new DbCommand(sql);
        db.AddParameter(result, ...);
        /* And so on */
        return result;
    }
