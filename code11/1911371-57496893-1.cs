    string queryString = "SELECT * FROM Davaoci";
    private DataSet PopuniDgDavaoci(DataSet ds, string connectionString, string queryString)
    {
        using (connection = new SqlConnection(connectionString))
        {
             SqlDataAdapter adapter = new SqlDataAdapter();
             adapter.SelectCommand = new SqlCommand(queryString, connection);
             adapter.Fill(ds);
        }
        
        return ds;
    }
