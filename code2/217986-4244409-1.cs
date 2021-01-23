    class MySqlConnection : IDatabase
    {
        public void connect()
        {
            ...
        }
    
        public void update()
        {         
            connect(); // here
            ...
        }
    }
