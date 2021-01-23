    public static IDbConnection RetrieveConnection(){
        if(DataAccess.Connection.State == ConnectionState.Open) return DataAccess.Connection;
        conn.Dispose(); //to be clean, I believe this is safe if it's already disposed
        //retrieve configured connection string
        //create and open connection
        return DataAccess.Connection;
    }
