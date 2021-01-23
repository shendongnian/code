    using (BCDataContext db = new BCDataContext())
    using (SqlConnection connection =  new SqlConnection(db.Connection.ConnectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "sproc_FindFoundries";
        command.CommandType = CommandType.StoredProcedure;
    
        command.Parameters.Add("@materials", SqlDbType.VarChar, 1000).Value = materialList;
        command.Parameters.Add("@capabilities", SqlDbType.VarChar, 1000).Value =  capabilityList;
    
        DataSet ds = new DataSet();
        using (SqlDataAdapter da = new SqlDataAdapter(command))
        {
            da.Fill(ds);
        }
    }
