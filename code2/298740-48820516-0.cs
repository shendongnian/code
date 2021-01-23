    private bool IsValidPath(string path, bool allowRelativePaths = false)
	{
		bool isValid = true;
		try
		{
			string fullPath = Path.GetFullPath(path);
			if (allowRelativePaths)
			{
				isValid = Path.IsPathRooted(path);
			}
			else
			{
				string root = Path.GetPathRoot(path);
				isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
			}
		}
		catch(Exception ex)
		{
			isValid = false;
		}
		return isValid;
	}
