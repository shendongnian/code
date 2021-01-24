    public string GetId()
    {
        using (var cmd = _context.Database.GetDbConnection().CreateCommand())
        {
            bool wasOpen = cmd.Connection.State == ConnectionState.Open;
            if (!wasOpen) cmd.Connection.Open();
            try
            {
                cmd.CommandText = "Select TOP 1 ID from ABC;";
                var result = (string)cmd.ExecuteScalar();
                return result;
            }
            finally
            {
                if (!wasOpen) cmd.Connection.Close();
            }
        }
    } 
