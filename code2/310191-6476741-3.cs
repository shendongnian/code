       using(OdbcConnection DbConnection = new  OdbcConnection(ConfigurationManager.AppSettings["ConnectionStr"]))
       {
              string cmdText = "SELECT Team_ID FROM team_details WHERE Team_Code=?";        
              OdbcCommand cmd = new OdbcCommand(cmdText, DbConnection);
              cmd.Parameters.Add("?Code", OdbcType.VarChar).Value = tbCode.Text;
              DbConnection.Open();
              OdbcDataReader DR = cmd.ExecuteReader();
              args.IsValid = DR.Read() && DR.GetValue(0) != DBNull.Value;
       }
