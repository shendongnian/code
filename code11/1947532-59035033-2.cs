      SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Trusted_Connection=True; 
           User Instance=yes");
      conn.Open();
      string sql2 = "UPDATE student SET moneyspent = " + ?????? + " WHERE id=" + studentIndex + ";";
      SqlCommand myCommand2 = new. 
      SqlCommand(sql2, conn);
