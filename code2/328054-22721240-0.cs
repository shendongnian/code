    if (mySQLConnection.State != ConnectionState.Open)
    {
        mySQLConnection.Close();
        mySQLConnection.Open();
    }
