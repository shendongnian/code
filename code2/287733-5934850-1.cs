             //Upload to mysql
             string connStr = "server=server;user=username;database=databasae;port=3306;password=password;";
             MySqlConnection conn = new MySqlConnection(connStr);
             conn.Open();
             foreach (Channel chan in results)
             {
                 // Perform databse operations
                 try
                 {
                     //Create sql statment with parameters
                     string sql = "INSERT INTO channels(ID, Name) VALUES (@id,@name)";
                     MySqlCommand cmd = new MySqlCommand(sql, conn);
                     cmd.Parameters.AddWithValue("@id", chan.ID);
                     cmd.Parameters.AddWithValue("@name", chan.Name);
                     cmd.ExecuteNonQuery();
                     updateStatus("Inserted");
                 }
                 catch (Exception ex)
                 {
                     updateStatus(ex.Message.ToString());
                 }
              }
              conn.Close();
