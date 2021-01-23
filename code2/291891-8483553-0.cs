        public Boolean AddUser(string user, string pass)
        {
            using (FbConnection con = new FbConnection(ConfigurationManager.ConnectionStrings["DBi"].ConnectionString.ToString()))
            {
                using (FbCommand fbComm = new FbCommand("INSERT INTO users (name, pass) VALUES ('" + user + "','" + pass + "')", con))
                {
                    fbComm.Connection.Open();
                    if (CheckUser(user, pass, con) == 0)                        
                    {
                        fbComm.ExecuteNonQuery();
                        return true;
                    }
                    fbComm.Connection.Close();
                }
            }
            return false;
        }
