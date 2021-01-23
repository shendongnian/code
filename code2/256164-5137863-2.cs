      public bool ValidateLogin(string username, string password)
      {
        MySqlConnection conn = new MySqlConnection("[YOURCONNECTIONSTRING]");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = new MySqlCommand("SELECT * FROM [YOURUSERTABLE] WHERE Username = ? AND Pass = ?", conn);
        adapter.SelectCommand.Parameters.Add("@Username", username);
        adapter.SelectCommand.Parameters.Add("@Password", password);
        adapter.Fill(dataset);
        
 
        If (dataset.HasRows)
        {
          // User is logged in maybe do FormsAuthentication.SetAuthcookie(username);
            return true;
        } else {
          // Authentication failed
          return false;
        }
      }
