    public static class DB 
    {
        private static string ConnectionString = @"Data Source=SAMSUNG-PC\SQLEXPRESS;Initial Catalog=LOGIN;Integrated Security=True";
    
        public static bool ValidateUserCredentials(string username, string password)
        {
                            //PwdHash column should Char(60) (not VarChar, not NCHar)
            string sql = "Select PwdHash from tbl_log where Username = @User";
       
            string hash = "";
            using (var cn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, cn))
            {
                //use actual column types and lengths from the database here
                // Do NOT use AddWithValue()!
                cmd.Parameters.Add("@User", SqlDbType.NVarChar, 20).Value = username;
    
                //keep the connection active for as brief a time as possible
                cn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return false;    
                    hash = (string)rdr["PwdHash"];
                }
            }
            //based on this NuGet bcrypt library:
            //https://www.nuget.org/packages/BCrypt-Official/
            if (BCrypt.Net.BCrypt.Verify(password, hash)) return true;
            return false;
        }
    }
