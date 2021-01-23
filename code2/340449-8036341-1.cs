    public static bool IsNullable(dynamic value)
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
