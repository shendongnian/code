    dbcon = new SQLiteConnection(connectionString);
    dbcon.Open();
    
    SQLiteCommand sqlComm;
    sqlComm = new SQLiteCommand("begin", dbcon);
    sqlComm.ExecuteNonQuery(); 
    //---INSIDE LOOP
    
     sqlComm = new SQLiteCommand(sqlQuery, dbcon);
    
     nRowUpdatedCount = sqlComm.ExecuteNonQuery(); 
    
    //---END LOOP
    sqlComm = new SQLiteCommand("end", dbcon);
    sqlComm.ExecuteNonQuery(); 
    dbcon.close();
