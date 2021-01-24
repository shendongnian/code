    private static readonly Dictionary<string, Action<object>> CommandWithParameter = new Dictionary<string, Action<object>>(StringComparer.InvariantCultureIgnoreCase)
		{ { "login", Login }, { "logout", Logout } };
	public static void Login(object parameter)
	{
		// cast it to string or whatever here if necessary
	}
	public static void Logout(object parameter)
	{
		// cast it to string or whatever here here if necessary
	}
