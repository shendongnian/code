        string dbName = "toto"; 
        var methods = new List<Action<SqlConnection, string>>
        {
            (connection) => DeleteCar(connection, dbName),
            (connection) => DeleteHouse(connection, dbName),
        };
        
        SqlConnection myDb;
        foreach (var action in methods)
        {
            action(myDb);
        }
