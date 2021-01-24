    MyDataSet m_myDataSet = new MyDataSet();
    
    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            sqlConnection.Open();
    
            using (SqlCommand cmd = new SqlCommand(selectCmd, sqlConnection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(m_myDataSet, tableName);
                }
            }
        }
    }
    catch (SqlException sqlEx)
    {
        // do some logging
        return false;
    }
