     //TODO: validate tableName and columnName here 
     //since formatting / string interpolation prone to SQL injection
     // e.g. 
     // if (!Regex.IsMatch(tableName, "^[A-Za-z][A-Za-z0-9_]*$")) {/* wrong table */}
     using (OdbcCommand delCmd = new OdbcCommand(
       $"ALTER TABLE {tableName} DROP COLUMN {columnName}", 
         dbConnection)) 
     { 
         delCmd.ExecuteNonQuery();
     }
