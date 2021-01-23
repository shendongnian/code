    var conn = new OracleConnection("your connection string"); // Or DB2Connection, SqlConnection or NpgsqlConnection or whatever...
    conn.Open();
    // Execute once:
    var cmd = conn.CreateCommand();
    cmd.CommandText = "DELETE FROM YOUR_TABLE WHERE YOUR_FIELD = :your_param";
    var param = cmd.CreateParameter();
    param.ParameterName = "your_param";
    param.DbType = ...;
    cmd.Parameters.Add(param);
    cmd.Prepare(); // Not really important for Oracle, but may be important for others.
    // Execute multiple times:
    param.Value = "some value";
    int row_count = cmd.ExecuteNonQuery();
    // If you are concerned with long-lived connections, you'll typically be able to do this:
    conn.Close();
    // ...
    conn.Open();
    param.Value = "some other value";
    row_count = cmd.ExecuteNonQuery();
    // Etc..
