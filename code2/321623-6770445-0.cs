    [ThreadStatic]
    private static MySqlConnection _connection;
    
    public static MySqlConnection GetConnection() {
        // no need for locks on a threadstatic field, obviously.
        if (_connection == null) {
            _connection = new MySqlConnection(...);
            _connection.Open();
        }
        return _connection;
    }
