      using (var cn = new OleDbConnection(strConn))
      {
        using (var cmd = new OleDbCommand("SELECT * FROM booking WHERE bdate = @bdate", cn))
        {
          cmd.Parameters.AddWithValue("@bdate", dtp_bdate.Value.Date);
          using (var rdr = OleDbDataReader = cmd.ExecuteReader)
          {
            while (rdr.Read())
            {
              
            }
          }
        }
      }
