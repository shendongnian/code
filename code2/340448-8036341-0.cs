    public static bool IsNullable(object value)
    {
        try
        {
            value = null;
        }
        catch(Exception)
        {
            return false;
        }
        return true;
    }
