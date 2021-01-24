    public async Task<bool> DeleteAllUser()
    {
        try
        {
            var queryUser = await this.connection.ExecuteAsync("delete from [UserLocal]");
            return true;
        }
        catch(Excpection e)
        {
            // log e
            return false;
        }
        finally
        {
            connection?.Close();
        }
    }
