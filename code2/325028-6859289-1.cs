    string[] vals = {"P", "Ab", "OD"}; // Don't know C# syntas for string array.
    connection.Open();
    // Start transaction with whatever it takes.
    for (int i = 1; i <= 8; i++) {
        string t1p = "Period" + i;;
        for (int j = 0; j < vals.length; j++) {
            command.CommandText = "update attendance_daily_rpt set " + t1p
                + " = '" + vals[j] +"' where " + t1p + " = '" + j + "'";
            command.ExecuteNonQuery();                
        }
    }
    // Commit transaction.
    connection.Close();
