	using System.DirectoryServices.AccountManagement;
	// ...
	// Connection information
	var connectionString = "LDAP://domain.com/DC=domain,DC=com";
	var connectionUsername = "your_ad_username";
	var connectionPassword = "your_ad_password";
	// Get groups for this user
	var username = "myusername";
	// Split the LDAP Uri
	var uri = new Uri(connectionString);
	var host = uri.Host;
	var container = uri.Segments.Count() >=1 ? uri.Segments[1] : "";
	// Create context to connect to AD
	var princContext = new PrincipalContext(ContextType.Domain, host, container, connectionUsername, connectionPassword);
	
	// Get User
	UserPrincipal user = UserPrincipal.FindByIdentity(princContext, IdentityType.SamAccountName, username);
	
	// Browse user's groups
	foreach (GroupPrincipal group in user.GetGroups())
	{
		Console.Out.WriteLine(group.Name);
	}
