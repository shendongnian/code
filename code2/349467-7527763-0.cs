        SqlCeConnection conn = new SqlCeConnection("Data Source = \\Program Files\\My         Program\\Program.sdf; Password ='mypassword'");
        conn.Open();
        try
          {
          SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM [NEW]", conn);
          SqlCeDataReader rdr = cmd.ExecuteReader();
          cmd.Connection = conn;
          cmd.ExecuteNonQuery();
              while (rdr.Read())
              {
              int param1 = rdr.GetInt32(0);
              int param2 = rdr.GetInt32(1);
              int param3 = rdr.GetInt32(2);
              int param4 = rdr.GetInt32(3);
              int param5 = rdr.GetInt32(4);
              int param6 = rdr.GetInt32(5);
              int param7 = rdr.GetInt32(6);
              string param8 = rdr.GetString(7);
              textBox1.AppendText(" " + param1 + " " + param2 + " " + param3 + " " + param4 + " " + param5 + " " + param6 + " " + param7 + " " + param8);
              textBox1.AppendText(System.Environment.NewLine);
              SqlCeCommand ins = new SqlCeCommand("insert into [OLD] values ('" + param1 + "','" + param2 + "','" + param3 + "','" + param4 + "','" + param5 + "','" + param6 + "','" + param7 + "','" + param8 + "');");
              ins.Connection = conn;              
              ins.ExecuteNonQuery();
              }
          }
         catch (Exception msg)
          {
         MessageBox.Show(msg.ToString());
          }
          conn.Close();
               
