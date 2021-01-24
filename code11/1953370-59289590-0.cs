    public string GetComputerName(string computerName)
    {
    	using (var context = new PrincipalContext(ContextType.Domain, "your domain name goes here"))
    	{
    		using (var group = GroupPrincipal.FindByIdentity(context, "Active Directory Group Name goes here"))
    		{
    			var computers = @group.GetMembers(true);
    			return computers.FirstOrDefault(c => c.Name == computerName).DistinguishedName;
    		}
    	}
    
    	return null; // or return "Not Found"
    }
