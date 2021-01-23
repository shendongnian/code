    SqlConnection connection; 
    try
    {
        connection = new SqlConnection ...;
        code code code then  return; 
    }
    finally
    {
       if (connection != null) connection.dispose();
    }
