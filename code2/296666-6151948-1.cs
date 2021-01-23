    public class AD
	{
		private LdapConnection ldapConn;
		private UsersWrapper users;
		public AD()
		{
			this.ldapConn = new LdapConnection(new Settings(/* configure settings here*/));
			this.users = new UsersWrapper(this.ldapConn);
		}
		public UsersWrapper Users
		{
			get
			{
				return this.users;
			}
		}
		public class UsersWrapper
		{
			private LdapConnection ldapConn;
			public UsersWrapper(LdapConnection ldapConn)
			{
				this.ldapConn = ldapConn;
			}
			public object Search()
			{
				return this.ldapConn.Search();
			}
			public void Add(object something)
			{
				this.ldapConn.Add(something);
			}
			public void Delete(object something)
			{
				this.ldapConn.Delete(something);
			}
		}
	}
