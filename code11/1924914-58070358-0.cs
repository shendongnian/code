    using ( var connection = new SqlConnection(strConnection) )
      if (connection != null)
        try 
        {
          connection.Open();
          // ...
        }
        catch (Exception ex)
        {
          // ...
        }
        finally
        {
          connection.Close();
        }
