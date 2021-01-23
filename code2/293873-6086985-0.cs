	class User
	{
		public User(string name, object picture)
		{
			Name = name;
			Picture = picture;
		}
		public string Name { get; set; }
		public object Picture { get; set; } //Change object to a class that holds Picture information.
	}
	class Profile : User
	{
		private static Profile _profile;
		public List<User> Friends = new List<User>(); //This List<T> can contain instances of (classes that derive from) User.
		public Profile(string name, object picture) : base(name, picture) { }
		public static Profile GetProfile()
		{
			return _profile ?? (_profile = new Profile("NameOfProfileHere", null));
		}
	}
