    public string GetCurrentUserName()
    {
    	if (!authenticated)
    	{
    		Response.Redirect(LoginScreen);
    		
    		throw new UnresolvedMethodException();
    	}
    	else
    	{
    		return UserName;
    	}
    }
