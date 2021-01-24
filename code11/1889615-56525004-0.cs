    using (SqlConnection con = new SqlConnection(dc.Con))
    {
        using (SqlCommand cmd = new SqlCommand("insert_territory", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;        
     	    cmd.Parameters.AddWithValue("@name",t.Name);
            cmd.Parameters.AddWithValue("@Regdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Regtime", DateTime.Now);
            con.Open();
            cmd.ExecuteNonQuery();
        }            
    }
