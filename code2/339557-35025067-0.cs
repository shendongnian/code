I guess you could even write an extension method for OleDbConnection...
    public static int GetLatestAutonumber(
        this OleDbConnection connection)
    {
        using (OleDbCommand command = new OleDbCommand("SELECT @@IDENTITY;", connection))
        {
            return (int)command.ExecuteScalar();
        }
    }
