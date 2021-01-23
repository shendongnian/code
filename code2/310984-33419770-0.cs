	/// <summary>
	/// Returns version like 2.1.15
	/// </summary>
	public static String ProductVersion
	{
		get
		{
			return new Version(FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion).ToString();
		}
	}
