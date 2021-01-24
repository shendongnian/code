    using (connection = new SqlConnection(connectionString)) 
    {
     using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Davaoci",connection ))
           {
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                DaDavaoci.DataSource = table;
            }
    }
  
