    bool? boolResult = null;
    int? intResult = null;
    
    if (dataReader.IsDBNull(reader.GetOrdinal("BOOL_FLAG")) == false)
    {
      boolResult  = dataReader.GetBoolean(reader.GetOrdinal("BOOL_FLAG"));
    }
    else
    {
      boolResult = true;
    }
    
    if (dataReader.IsDBNull(reader.GetOrdinal("INT_VALUE")) == false)
    {
       intResult= dataReader.GetInt32(reader.GetOrdinal("INT_VALUE"));
    }
    else
    {
       intResult = 0;
    }
