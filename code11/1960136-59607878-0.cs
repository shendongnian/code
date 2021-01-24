     using (MySqlDataReader reader = cmd.ExecuteReader())
            {               
                while (reader.Read())
                {
                    nomeCorrente = reader.GetString("nome");
                    cognomeCorrente = reader.GetString("cognome");                 
                }
                reader.Close();              
            }
            idCorrente = db.QueryId("SELECT id FROM thewishlist.user WHERE email='" + user.Text + "'");
            db.CloseConnection();
