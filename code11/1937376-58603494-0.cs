      using ( var con = new OracleConnection(conString) ) {
         con.Open();
         var pullCmd = new OracleCommand("select * FROM usertable where last_name = :lastName", con);
         pullCmd.Parameters.Add("lastName", OracleDbType.Varchar2, ParameterDirection.Input).Value = "Smith";
         var dt = new DataTable();
         var da = new OracleDataAdapter(pullCmd);
         da.Fill(dt);
         var pushCmd = new OracleCommand("INSERT INTO new_table (first_name, middle_name, last_name, department) VALUES (:first_name, :middle_name, :last_name, :department)", con);
         pushCmd.Parameters.Add("first_name", OracleDbType.Varchar2, ParameterDirection.Input);
         pushCmd.Parameters.Add("middle_name", OracleDbType.Varchar2, ParameterDirection.Input);
         pushCmd.Parameters.Add("last_name", OracleDbType.Varchar2, ParameterDirection.Input);
         pushCmd.Parameters.Add("department", OracleDbType.Varchar2, ParameterDirection.Input);
         foreach ( DataRow row in dt.Rows ) {
            pushCmd.Parameters["first_name"].Value = row["first_name"];
            pushCmd.Parameters["middle_name"].Value = row["middle_name"];
            pushCmd.Parameters["last_name"].Value = row["last_name"];
            pushCmd.Parameters["department"].Value = row["department"];
            pushCmd.ExecuteNonQuery();
         }
         con.Close();
      }
