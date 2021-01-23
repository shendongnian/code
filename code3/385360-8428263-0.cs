    Dictionary<string, string> cValues = new Dictionary<string, string>();
    
    // Create DbDataReader to Data Worksheet
    using (DbDataReader dr = command.ExecuteReader())
    {
       while (dr.Read()) {
          string sValue = dr[0].ToString();
          if (cValue.ContainsKey(sValue)) {
             // There is a duplicate value, so bail
             throw new Exception("Duplicate value " + sValue);
          } else {
             cValues.Add(sValue, sValue);
          }
       }
    }
    
    // Now execute the reader on the command again to perform the upload
    using (DbDataReader dr = command.ExecuteReader())
