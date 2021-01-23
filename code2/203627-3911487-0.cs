    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
    sqlReader.NextResult(); // Skip first result set.
    sqlReader.NextResult(); // Skip second result set.
    while (sqlReader.Read())
    {
        var netTaxableIncome = sqlReader.GetValue(0);
    }
