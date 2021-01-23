    public bool UpdateCustomerIAR(IAR oIAR)
    {
        bool bRetVal = false;
        try
        {
           MySqlConnection dbConnection = new MySqlConnection(APPSConn.ConnectionString);
           MySqlCommand dbCommand = dbConnection.CreateCommand();
           string szSQL = string.Empty;
           szSQL = "UPDATE schema.table_name SET field_name_one=?field_name_one";
           szSQL += " WHERE field_name_two=?field_name_two";
           using (MySql.Data.MySqlClient.MySqlConnection conn = new
    MySql.Data.MySqlClient.MySqlConnection(APPSConn.ConnectionString))
            {
              MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
              cmd.Connection = conn;
              cmd.CommandText = szSQL;
              cmd.Parameters.AddWithValue("?field_name_one", oIAR.Title);
              cmd.Parameters.AddWithValue("?field_name_two", oIAR.IARID.ToString());
              conn.Open();
              cmd.ExecuteNonQuery();
              bRetVal = true;
          }
          return bRetVal;
       }
       catch (MySqlException ex)
       {
          ErrorHandler(ex.ToString());
          return bRetVal;
       }
       catch (Exception ex)
       {
          ErrorHandler(ex.ToString());
          return bRetVal;
       }
    }
