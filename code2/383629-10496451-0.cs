    MySqlConnection Conn = new MySqlConnection();
    MySqlCommand Cmd = new MySqlCommand();   
     Conn.ConnectionString="Server=localhost;Port=3306;Database=database;Uid=root;Pwd=root";
        Cmd.Connection = Conn;
        Cmd.CommandText = "Statment";
        Conn.Open();
        // for Insert or Update or Delete
        Cmd.ExecuteNonQuery();
        
        //for Select
        Cmd.ExecuteReader()
        
        Conn.Close();
