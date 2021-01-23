    using System.Data.SqlTypes;
    
    class MyModelType
    {
        public Guid ID { get; set; }
        public byte[] Data { get; set; }
    }
    
    static readonly object NullSqlBinary = new object();
    
    object SqlValueForObject(object val)
    {
        if (val == null)
        {
            val = DBNull.Value;
        }
        else if (val == NullSqlBinary)
        {
            val = SqlBinary.Null;
        }
        return val;
    }
    
    IDictionary<string, object> Params(MyModelType x)
    {
        return new Dictionary<string, object>
        {
            { "@ID", x.ID },
            { "@Data", x.Data ?? NullSqlBinary },
        };
    }
    
    private SqlCommand CreateCommand()
    {
        var cmd = Connection.CreateCommand();
        cmd.CommandTimeout = 60;
    
        return cmd;
    }
    
    SqlCommand CreateCommand(string sql, IDictionary<string, object> values)
    {
        var cmd = CreateCommand();
        cmd.CommandText = sql;
        cmd.Transaction = GetCurrentTransaction();
    
        cmd.Parameters.Clear();
        if (values != null)
        {
            foreach (var kvp in values)
            {
                object sqlVal = SqlValueForObject(kvp.Value);
                cmd.Parameters.AddWithValue(kvp.Key, sqlVal);
            }
        }
        return cmd;
    }
    int Execute(string sql, IDictionary<string, object> values)
    {
        using (var cmd = CreateCommand(sql, values))
        {
            return cmd.ExecuteNonQuery();
        }
    }
    
    void InsertMyModel(MyModelType obj)
    {
        DB.Execute(
            @"INSERT INTO MyTable (ID, Data)
            VALUES (@ID, @Data)", Params(obj));
    }
