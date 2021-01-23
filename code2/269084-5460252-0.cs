    public static List<string> GetDovizTurleribySP()
    {
      string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer1"].ConnectionString;
      using (SqlConnection sqlConn = new SqlConnection(connString))
      {
        sqlConn.Open();
        List<string> dovizTanimlari = new List<string>();
        string commandGetDovizTanimlari = "EXEC GetDovizTanimlari";
        SqlCommand cmd;
        cmd = new SqlCommand(commandGetDovizTanimlari, sqlConn);
            
        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            dovizTanimlari.Add(reader.GetString(0));
          }
        }
        return dovizTanimlari;
      }
    }
