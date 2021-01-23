    string insertString = "INSERT INTO [TableName] ([ColumnName]) Values (@value)";
    SQLiteCommand command = new SQLiteCommand();
    command.Parameters.AddWithValue("@value", value);
    command.CommandText = insertString;
    command.Connection = dbConnection;
    SQLiteTransaction transaction = dbConnection.BeginTransaction();
    try
    {
        command.ExecuteNonQuery();
        transaction.Commit();
        return true;
    }
    catch (SQLiteException ex)
    {
        transaction.Rollback();
    }
