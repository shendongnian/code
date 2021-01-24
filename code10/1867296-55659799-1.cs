    updateCommand.Parameters.AddWithValue("@Var" , "Johne");
    
        try
        {
            connection.Open();
            int count = updateCommand.ExecuteNonQuery;
            if (count > 0)
                return true;
            else
                return false;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
