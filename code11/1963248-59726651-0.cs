cs
        private void delQuery(int token)
        {
            //SETUP CONNECTION
            MySqlConnection dbConn = new MySqlConnection("some connection");
            //OPEN CONNECTION
            dbConn.Open();
            //DELETE TOKEN
            MySqlCommand delcmd = new MySqlCommand("DELETE FROM tokens WHERE token = " + token, dbConn);
            MySqlDataReader dbReader = delcmd.ExecuteReader();
            dbReader.Read();
            //CLOSE CONNECTION
            dbConn.Close();
        }
called it using:
cs
if (dbRead.Read())
            {
                int sqlkey = int.Parse(dbRead["token"].ToString());
                if (keyint == sqlkey)
                {
                    dbCon.Close();
                    delQuery(keyint);
                }
            }
