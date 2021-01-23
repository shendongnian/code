    bool CheckTableExists()
    {
        try
        {
            context.YourTable.Where(s => s.<yourKeyField> = <impossible value>).Count();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
