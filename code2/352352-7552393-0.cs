    try
    {
        using (var connection = new SqlConnection(Utils.ConnectionString))
        {
            connection.Open();
            using (var cmd = new SqlCommand("StoredProcedure", connection))
            {                            
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var sqlParam = new SqlParameter("id_document", idDocument);
                cmd.Parameters.Add(sqlParam);
    
                int result = cmd.ExecuteNonQuery();
                if (result != -1)
                    return "something";
    
                //do something here
    
                return "something else";
    
            }
    
            connection.Close();
            connection.Dispose();
        }
    
        //do something
    
    }
    catch (SqlException ex)
    {
        return "something AKA didn't work";
    }
