    public Task<bool> SignIn(User user)
    {
        try
        {
            ...
            return await SIn();
        }
        catch (Exception e)
        {
            return false;
        }
    }
