    string server = "steve-pc";
    string database = "itcast2014";
    string username = "YourMysqlUsername";
    string password = "YourMysqlPassword";
    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}",server, database, username, password);
    
    
    using(var connection = new MySqlConnection(connstring);
    {  
        connection.Open();
    
        string query = "select count(*) from TblPerson";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            string personsCount = reader.GetString(0);
            Console.WriteLine(personsCount);
        }
        connection.Close();
    }
