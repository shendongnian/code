    var sqlMetaData = new[] 
    {  
      new SqlMetaData("Id", SqlDbType.Int, true, false, SortOrder.Unspecified, -1),   
      new SqlMetaData("StudentId", SqlDbType.Int)
    };
    
    var record = new SqlDataRecord(sqlMetaData);   
    record.SetInt32(1, 201);   
    List<SqlDataRecord> sqlRecords = new List<SqlDataRecord>();
    sqlRecords.Add(record);
    
    parameters.Add(new SqlParameter("@TableLeaveID", sqlRecords));
