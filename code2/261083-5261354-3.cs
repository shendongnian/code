    public ActionResult Login(LoginData loginData)
    {
        try
        {
            // All your logic here WITHOUT any try/catch blocks
        }
        catch (Exception ex)
        {
            // Rethrow, wrapping the Exception with a LoginFailureException
            throw new LoginFailureException(ex);
        }
    }
