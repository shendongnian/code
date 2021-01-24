    interface IDatabaseClient
    {
        Task ConnectAsync();
        Task AddDataAsync<T>(string databaseName, T data);
    }
    class DatabaseClient1 : IDatabaseClient
    {
        public DatabaseClient1(string username, string password)
        {
            Username = username;
            Password = password;
        }
    
        public string Username { get;  }
    
        public string Password { get;  }
    
        public async Task ConnectAsync()
        {
            // connect using Username and Password
        }
        public async Task AddDataAsync<T>(string databaseName, T data)
        {
            // Not sure if you can work with a generic method for inserting data
            // into your database, but given that you didn't specify your 
            // requirements further, I'm just going to go with this
        }
    }
