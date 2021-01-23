		public static bool Authenticate(string user, string password)
		{
			// Split the user name in case a domain name was specified as DOMAIN\USER
			string[] NamesArray = user.Split(new char[] { '\\' }, 2);
			// Default vars for names & principal context type
			string DomainName = string.Empty;
			string UserName = string.Empty;
			ContextType TypeValue = ContextType.Domain;
			// Domain name was supplied
			if (NamesArray.Length > 1)
			{
				DomainName = NamesArray[0];
				UserName = NamesArray[1];
			}
			else
			{
				// Pull domain name from environment
				DomainName = Environment.UserDomainName;
				UserName = user;
				// Check this against the machine name to pick up on a workgroup
				if (string.Compare(DomainName, System.Environment.MachineName, StringComparison.InvariantCultureIgnoreCase) == 0)
				{
					// Use the domain name as machine name (local user)
					TypeValue = ContextType.Machine;
				}
			}
			// Create the temp context
			using (PrincipalContext ContextObject = new PrincipalContext(TypeValue, DomainName))
			{
				// Validate the credentials
				return ContextObject.ValidateCredentials(UserName, password);
			}
		}
