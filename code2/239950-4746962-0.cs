    public static string GetNameById(int id)
    {
        string name;
        try
        {
            //Connect to Db and get name - some error occured
        }
        catch(Exception ex)
        {
            Log(ex);
            throw; // Re-throw the exception, don't throw a new one...
        }
        return name;
    }
