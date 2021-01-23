    public static DataSet GetDataSet(string sql, DatabaseType database)
    {
        using ( var connection = new SqlConnection( GetConnectionString(database) ) )
        {
            using (var adapter = new SqlDataAdapter(sql, connection))
            {
                var temp = new DataSet();
                adapter.Fill(temp);
                return temp;
            }
        }
    }
