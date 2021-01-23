    StringBuilder sb = new StringBuilder();
    
    
    foreach(Thing thing in Something)
    {
        string query = BuildMyQuery(thing);
        sb.Append(query);
        sb.Append("GO");
    }
    
    string SQLText = sb.ToString();
    
    // Execute SQL Command here using SQL Text
