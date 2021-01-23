    public DataTable Read1(string query)
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = query;
            cmd.Connection.Open();
            var table = new DataTable();
            using (var r = cmd.ExecuteReader())
                table.Load(r);
            return table;
        }
    }
    public DataTable Read2<S>(string query) where S : IDbDataAdapter, IDisposable, new()
    {
        using (var da = new S())
        {
            using (da.SelectCommand = conn.CreateCommand())
            {
                da.SelectCommand.CommandText = query;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
    public IEnumerable<S> Read3<S>(string query, Func<IDataRecord, S> selector)
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = query;
            cmd.Connection.Open();
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    yield return selector(r);
        }
    }
    public S[] Read4<S>(string query, Func<IDataRecord, S> selector)
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = query;
            cmd.Connection.Open();
            using (var r = cmd.ExecuteReader())
                return ((DbDataReader)r).Cast<IDataRecord>().Select(selector).ToArray();
        }
    }
    public List<S> Read5<S>(string query, Func<IDataRecord, S> selector)
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = query;
            cmd.Connection.Open(); 
            using (var r = cmd.ExecuteReader())
            {
                var items = new List<S>();
                while (r.Read())
                    items.Add(selector(r));
                return items;
            }
        }
    }
