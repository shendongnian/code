    using (SqlConnection conn = new SqlConnection(connectionString))
    {   
      conn.Open();  
      foreach (DataRow r in dataTable2.Rows)
      {
        string sql = "INSERT INTO BALREP (ACODE, ANAME, QTY) VALUES ('" +r["CODE"] + "', '" + r["NAME"] + "', '" + r["CELL"] + "')";
        SqlCommand cmd2 = con.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
      }
    }
