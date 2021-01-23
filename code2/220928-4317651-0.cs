        public bool IsValidUser(string username, string password)
        {
            int count = 0;
            // Get the data from the iSeries
            using (iDB2Connection conn = new iDB2Connection(ConfigurationManager.ConnectionStrings["IbmIConnectionString"].ConnectionString))
            {
                string sqlStatement = "SELECT COUNT(XXXXXX) FROM XXXXXX WHERE UPPER(XXXXXX) = @1 AND XXXXXX = @2";
                iDB2Command cmd = new iDB2Command(sqlStatement, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@1", username.ToUpper());
                cmd.Parameters.Add("@2", password);
                conn.Open();
                count = (Int32)cmd.ExecuteScalar();
                conn.Close();
            }
            return ((count == 0) ? false : true);
        }
