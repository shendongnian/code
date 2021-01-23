    // Connection string for your app
    string constr = "User Id=scott;Password=tiger;Data Source=oracle"; 
    
    // Creates new connection object.
    OracleConnection con = new OracleConnection(constr);
    con.Open();
    string cmdstr = "SELECT * FROM EMPINFO";
    OracleConnection connection = new OracleConnection(constr);
    OracleCommand cmd = new OracleCommand(cmdstr, con);
    OracleDataReader reader = cmd.ExecuteReader();
    // Reads all rows one by one
    // If you are sure that only one row will be returned from your query,
    // you can omit while.
    while (reader.Read())
    {
        // Returns the first column of the row and converts it to Int32.
        // You should replace '0' with the column no you desire.
        return reader.GetInt32(0);
    }
