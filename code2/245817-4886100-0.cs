    public DataTable CommandWithParams(string sql, Dictionary<string, object> parameters)
    {
        using (var query = new MySqlCommand(sql))
        {
            foreach (var param in parameters)
            {
                query.Parameters.AddWithValue(param.Key, param.Value);
            }
            return _connection.RetreiveData(query);
        }
    }
