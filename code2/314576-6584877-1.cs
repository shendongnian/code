<!-- -->   
 
    DataSet GetDataSet(string sqlCommand, string connectionString)
    {
        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand(
            sqlCommand, new SqlConnection(connectionString)))
        {
            cmd.Connection.Open();
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            ds.Tables.Add(table);
        }
        return ds;
    }
