    public class AD : LdapConnection
	{
		private UsersWrapper users;
		public AD(Settings settings) : base(settings)
		{
			this.users = new UsersWrapper(this);
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
			private AD parent;
			public UsersWrapper(AD parent)
			{
				this.parent = parent;
			}
			public object Search()
			{
				return this.parent.Search();
			}
			public void Add(object something)
			{
				this.parent.Add(something);
			}
			public void Delete(object something)
			{
				this.parent.Delete(something);
			}
		}
	}
