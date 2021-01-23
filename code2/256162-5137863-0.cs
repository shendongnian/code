      MySqlConnection conn = new MySqlConnection(connection);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = new MySqlCommand("SELECT * FROM [YOURUSERTABLE] WHERE Username = '" + username + "' AND Pass = '" + Password + "'", conn);
        adapter.Fill(dataset);
        
    
    If (dataset.HasRows)
    {
        // User is logged in maybe do FormsAuthentication.SetAuthcookie(username);
    } else {
        // Authentication failed
    }
