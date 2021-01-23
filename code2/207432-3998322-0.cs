    public static IDbConnection RetrieveConnection(){
        //retrieve the possible active connection
        if(conn.State == ConnectionState.Open) return conn;
        conn.Dispose(); //to be clean, I believe this is safe if it's already disposed
        //retrieve connection information
        //create and open connection
        return conn;
    }
