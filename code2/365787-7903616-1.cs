    public NpgsqlDataReader DoQuery()
    {
        bool ownershipPassed = false;
        NpgsqlConnection conn = GetConnectionCode();
        try
        {
            NpgsqlCommand c = new NpgsqlCommand(...);
            NpgsqlDataReader dataread = c.ExecuteReader(CommandBehavior.CloseConnection);
            ownershipPassed = true;
            return dataread;
        }
        finally
        {
            if(!ownershipPassed)//only if we didn't create the reader than takes charge of the connection
              conn.Dispose();
        }
    }
