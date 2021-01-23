    public static bool IsLogged(this Exception exception)
    {
        if (exception.Data.Contains("IsExceptionLogged"))
        {
            return (bool)exception.Data["IsExceptionLogged"];
        }
        return false;
    }
        
    public static void SetLogged(this Exception exception)
    {
        exception.Data.Add("IsExceptionLogged", true);
    }
