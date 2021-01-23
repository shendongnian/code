    public T ExecuteScalar<T>(string sSql, params SqlParameter[] parameters)
    {
        if (!string.IsNullOrEmpty(sSql))
        {
            DataAccess dal = new DataAccess(ConnectionString);
            DebugOutput_SQL(sSql, parameters);
            object value = null;
            value = dal.ExecuteScalar(sSql, parameters);
            if (value != null && value != DBNull.Value)
                return (T) Convert.ChangeType(value, typeof(T));
        }
        return default(T);
    }
