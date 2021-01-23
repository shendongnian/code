    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(myConnString))
    {
        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
        {
            cmd.CommandText = "myMultipleTablesSP";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
        }
    }
