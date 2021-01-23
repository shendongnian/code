    public override bool ValidateUser(string username, string password)
    {
    	bool isValid = false;
    	bool isApproved = false;
    	string pwd = "";
    
    	using (AdminModelContext db = new AdminModelContext())
    	{
    		var user = db.Users.FirstOrDefault(u => u.UserName == username);
    		if (user != null)
    		{
    			pwd = user.Password;
    			isApproved = user.IsApproved;
    
    			if (CheckPassword(password, pwd))
    			{
    				if (isApproved)
    				{
    					isValid = true;
    
    					user.LastLoginDate = DateTime.Now;
    					user.LastActivityDate = DateTime.Now;
    
    					try
    					{
    						db.SubmitChanges();
    					}
    					catch (Exception ex)
    					{
    						Console.WriteLine(ex);
    					}
    				}
    			}
    			else
    			{
    				UpdateFailureCount(username, "password");
    			}
    		}
    	}
    
    	return isValid;
    }
