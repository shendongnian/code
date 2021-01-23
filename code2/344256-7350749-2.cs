    private DataTable PerformQuery(string sql, System.DateTime startdate, System.DateTime enddate)
     { 
         var tblvisits = new DataTable();
         using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionstring))
         {
             conn.Open();
             var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
             var ds = new DataSet();
             var parameter = new MySql.Data.MySqlClient.MySqlParameter("@startdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
             parameter.Direction = ParameterDirection.Input;
             parameter.Value = startdate.ToString(dateformat);
             cmd.Parameters.Add(parameter);
             var parameter2 = new MySql.Data.MySqlClient.MySqlParameter("@enddate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
             parameter2.Direction = ParameterDirection.Input;
             parameter2.Value = enddate.ToString(dateformat);
             cmd.Parameters.Add(parameter2);
             var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
             da.Fill(ds);
             try
             {
                 tblvisits = ds.Tables[0];
             }
             catch
             {
                tblvisits = null;
             }
         }
         return tblvisits;
     }
