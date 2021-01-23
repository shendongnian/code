      DataTable dt = new DataTable();
      using (var cn = new OleDbConnection(strConn))
      {
        cn.Open();
        using (var cmd = new OleDbCommand("SELECT * FROM booking WHERE bdate = @bdate", cn))
        {
          cmd.Parameters.AddWithValue("@bdate", dtp_bdate.Value.Date);
          using (OleDbDataAdapter oda = new OleDbDataAdapter(cmd))
            oda.Fill(dt);
        }
      }
