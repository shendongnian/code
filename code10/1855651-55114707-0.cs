    using (var conn = new SQLiteConnection(connectionString))
    {
        using (var cmd = new SQLiteCommand(query, conn))
        {
            await conn.OpenAsync();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                 onDataReturned?.Invoke(reader);       
            }
        }
    }
