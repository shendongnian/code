    HashSet<string> ScannedRecords = new HashSet<string>();
    foreach (var row in dtCSV.Rows)
    {
        // Build a string that contains the combined column values
        StringBuilder sb = new StringBuilder();
        foreach (string col in columns)
        {
            sb.AppendFormat("[{0}={1}]", col, row[col].ToString());
        }
        // Try to add the string to the HashSet.
        // If Add returns false, then there is a prior record with the same values 
        if (!ScannedRecords.Add(sb.ToString())
        {
            // This record is a duplicate.
        }
    }
