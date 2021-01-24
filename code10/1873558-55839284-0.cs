     string query= @"INSERT INTO entries(nif,active,date, entry_time) 
                     VALUES (@nif, @active, @d, @e)";
     MySqlCommand com = new MySqlCommand(query, connection);
     com.Parameters.Add("@nif", MySqlDbType.VarChar).Value = nif;
     com.Parameters.Add("@active", MySqlDbType.Int32).Value = active;
     com.Parameters.Add("@d", MySqlDbType.Date).Value = dateNow;
     com.Parameters.Add("@e", MySqlDbType.Time).Value = timeNow;
     ret= com.ExecuteNonQuery();
