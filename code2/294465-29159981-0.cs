    bool CheckTableExists()
    {
        try
        {
            context.YourTable.Count();
            return true;
        }
        catch (EntityCommandExecutionException)
        {
            return false;
        }
    }
