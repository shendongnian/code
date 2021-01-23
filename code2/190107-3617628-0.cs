    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlComamnd command = connection.CreateCommand())
    {
        command.CommandText = commandText;
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@lat1", SqlDbType.Float,50, lat1).Value = lat1;
        command.Parameters.Add("@lng1", SqlDbType.Float,50, lng1).Value = lng1;
        command.Parameters.Add("@radius1", SqlDbType.Int,10, radius1).Value = radius1;
        command.Parameters.Add("@streetname", SqlDbType.VarChar, 50, streetname).Value = streetname;
        command.Parameters.Add("@keyword1", SqlDbType.VarChar, 50, keyword1).Value = keyword1;
        connection .Open();
        DataSet ds = new DataSet();
        using (SqlDataAdapter adapter = neq SqlDataAdapter(command))
        {
            adapter.Fill(ds);                
        }
    }
