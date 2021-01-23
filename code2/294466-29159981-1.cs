    bool CheckTableExists()
    {
        try
        {
            context.YourTable.Count();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
