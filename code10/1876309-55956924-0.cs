    public void Migrate()
    {
        Database.Migrate();
        using (var connection = (NpgsqlConnection)Database.GetDbConnection())
        {
            connection.Open();
            connection.ReloadTypes();
        }
    }
