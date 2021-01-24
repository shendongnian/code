    string strConnect = @"Data Source=GRIFFPC\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True";
    using (SqlConnection con = new SqlConnection(strConnect))
        {
        con.Open();
        using (SqlBulkCopy bulk = new SqlBulkCopy(con))
            {
            bulk.DestinationTableName = "Test";
            bulk.WriteToServer(dt);
            }
        }
