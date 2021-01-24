    // Prepare the statement
    var statement = $"INSERT INTO MDB_{oracleTableName} ({fields}) VALUES (:p0";
    for (int i = 1; i < fieldSpecs.Count; ++i) {
        statement = statement  + ",:p1";
    }
    statement = statement  + ")";
    var cmd = new OracleCommand(statement, oracleConnection);
    
    // Add parameters
    for (int i = 0; i < fieldSpecs.Count; ++i) {
        cmd.Parameters.Add(String.Format("p{0}", i), OracleDbType.Varchar2); 
        // needs to be more advanced in order to cover also other data types, not just Varchar2
    }
       
    // Assign parameter values and execute
    while (accessReader.Read()) {
        for (int i = 0; i < fieldSpecs.Count; ++i) {
            cmd.Parameters[i].Value = accessReader[i];
        }
        cmd.ExecuteNonQuery();
    }
                   
