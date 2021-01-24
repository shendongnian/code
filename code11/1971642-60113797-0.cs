    public static void getGroupsWithUsers() 
    {
    	String currentDomain = Domain.GetCurrentDomain().ToString();
    	var stringBuilder = new StringBuilder();
    	
    	using (PrincipalContext context = new PrincipalContext(ContextType.Domain, currentDomain))
    	{
    		using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(context)))
    		{
    			foreach (var result in searcher.FindAll())
    			{
    				DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
    				var SID = WindowsIdentity.GetCurrent().User.ToString();
    
    				// find a user
    				UserPrincipal user = UserPrincipal.FindByIdentity(context, de.Properties["samAccountName"].Value.ToString());
    
    				if (user != null)
    				{
    					// get the user's groups
    					var groups = user.GetAuthorizationGroups();
    
    					foreach (GroupPrincipal group in groups)
    					{
    						stringBuilder.AppendLine($"User: {user} is in Group: {group}");
    					}
    				}
    			}
    		}
    	}
    	
    	string result = stringBuilder.Length > 0
    		? stringBuilder.ToString()
    		: "No users were found";
    	
    	Console.WriteLine(result);
    } 
