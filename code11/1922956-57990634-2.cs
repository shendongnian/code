    // This dictionary will be used for field position lookups
    var columnOrderDict = new Dictionary<string, int>(); 
    for (var i = 0; i < columnsNames.Length; i++)
    {
        columnOrderDict[columnsNames[i]] = i;   
    }
    
    cmd3.Connection = conn;
    cmd3.CommandType = CommandType.StoredProcedure;
    cmd3.CommandText = "CustomerInfoProcedure";
    for (var j = 0; j < parameterOrder.Length; j++)
    {
        var currentFieldName = parameterOrder[j];
        if (columnOrderDict.ContainsKey(currentFieldName))
        {
            cmd3.Parameters.AddWithValue(currentFieldName, values[columnOrderDict[currentFieldname]]);
        } else {
            cmd3.Parameters.AddWithValue(currentFieldName, DBNull.Value);
        }
    }
