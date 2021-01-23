    public static bool Throws(this Action action)
    {
        try
        {
            action.Invoke();
        }
        catch (Exception)
        {
           return true;
        }
        return false;
    }
