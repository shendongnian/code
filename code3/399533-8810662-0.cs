	public static bool IsSpecialFolder(string folderPath)
	{
		foreach (Environment.SpecialFolder specialFolderType in Enum.GetValues(typeof (Environment.SpecialFolder)))
		{
			var specialFolderLocation = Environment.GetFolderPath(specialFolderType);
			if(specialFolderLocation.Equals(folderPath, StringComparison.InvariantCultureIgnoreCase))
				return true;
		}
		return false;
	}
