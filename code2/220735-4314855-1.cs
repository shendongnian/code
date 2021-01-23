        using (SqlConnection con = new SqlConnection(datasource))
        using (SqlCommand cmd = new SqlCommand("Select * from MyTable Where ID='1' ", con))
        {
            cmd.CommandTimeout = 300;
            con.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            using (DataSet ds = new DataSet())
            {
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
