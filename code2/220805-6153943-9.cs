    private void ResolveGroup(SPWeb w, string name, List<string> users)
    {
    	foreach (SPPrincipalInfo i in SPUtility.GetPrincipalsInGroup(w, name, 100, out b))
    	{
    		if (i.PrincipalType == SPPrincipalType.SecurityGroup)
    		{
    		  ResolveGroup(w, i.LoginName, users);
    		}
    		else
    		{
    		  users.Add(i.LoginName);
    		}
    	}
    }
    
    List<string> users = new List<string>();
    foreach (SPUser user in SPContext.Current.Web.AllUsers)
    {
      if (user.IsDomainGroup)
    	{
    	  ResolveGroup(SPContext.Current.Web, user.LoginName, users);
    	}
    	else
    	{
    	  users.Add(user.LoginName);
    	}
    }
