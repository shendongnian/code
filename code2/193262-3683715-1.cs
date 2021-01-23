    //calculates the column ordinal based on column name
    int ThreadResponseColumnIdx = reader.GetOrdinal("ThreadResponse");
    
    //If there is a line in the result
    if (reader.Read())
    {
      //read from the current line the ThreadResponse column
      result.TextContent = reader.GetString(ThreadResponseColumnIdx);
    }
