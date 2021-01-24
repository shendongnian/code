    await _dbContext.Database.OpenConnectionAsync();
    try
    {
        var result = await cmd.ExecuteScalarAsync();
        if (result != null)
        {
            return Convert.ToInt32(result);
        }
        return null;
    }
    finally
    {
        _dbContext.Database.CloseConnection();
    }
