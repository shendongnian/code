    private string GetCaseSensitivePath(string path)
	{
		var root = Path.GetPathRoot(path);
		try
		{
			foreach (var name in path.Substring(root.Length).Split(Path.DirectorySeparatorChar))
				root = Directory.GetFileSystemEntries(root, name).First();
		}
		catch (Exception e)
		{
			// Log("Path not found: " + path);
			root += path.Substring(root.Length);
		}
		return root;
	}
