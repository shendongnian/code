    public static bool Throws<T>(this Action action, bool discardExceptions = false) 
        where T : Exception
    {
        try
        {
            action.Invoke();
        }
        catch (T)
        {
            return true;
        }
        catch (Exception)
        {
            if (discardExceptions)
            {
                return false;
            }
            throw;
        }
        return false;
    }
