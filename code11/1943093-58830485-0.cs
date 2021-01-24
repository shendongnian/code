    public DataTable GetDataTable(string connectionString, string tableName)
    {
    SqlConnection conn = new SqlConnection(connectionString);
    conn.Open();
    string query = $'SELECT * FROM [{tableName}]';
    
    SqlCommand cmd = new SqlCommand(query, conn);
    
    DataTable t1 = new DataTable();
    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
    {
        a.Fill(t1);
    }
    return t1;
    }
