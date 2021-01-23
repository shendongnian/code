		public static bool Authenticate(string user, string password)
		{
			string[] Values = user.Split(new char[] { '\\' }, 2);
			string DomainName = string.Empty;
			ContextType TypeValue = ContextType.Domain;
			if (Values.Length > 1)
			{
				DomainName = Values[0];
				user = Values[1];
			}
			else
			{
				DomainName = System.Environment.MachineName;
				TypeValue = ContextType.Machine;
			}
			using (PrincipalContext ContextObject = new PrincipalContext(TypeValue, DomainName))
			{
				// validate the credentials
				return ContextObject.ValidateCredentials(user, password);
			}
		}
