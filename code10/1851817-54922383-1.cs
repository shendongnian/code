    private void Updateinfo(string fvzitter, string info, string zetels, string stroming, string partij)
    {
       string query = "UPDATE partijen SET fvzitter=@fvzitter, info=@info, zetels=@zetels, stroming=@stroming WHERE partij=@partij"
       conn.Open();
       MySqlCommand command = conn.CreateCommand();
       command.CommandText = query;
       command.Parameters.AddWithValue("@fvzitter", fvzitter);	
       command.Parameters.AddWithValue("@info", info);
       command.Parameters.AddWithValue("@zetels", zetels);
       command.Parameters.AddWithValue("@stroming", stroming);
       command.Parameters.AddWithValue("@partij", partij);
    
       command.ExecuteNonQuery();
       conn.Close();
    }
