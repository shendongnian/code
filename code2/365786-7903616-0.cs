    public NpgsqlDataReader DoQuery()
    {
        using(NpgsqlConnection = GetConnectionCode())
        {
            NpgsqlCommand c = new NpgsqlCommand(...);
            NpgsqlDataReader dataread = c.ExecuteReader();
            return dataread;
        }//Connection closes at this using-scope being left because that triggers Dispose()
    }
