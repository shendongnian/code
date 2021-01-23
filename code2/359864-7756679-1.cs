	static IEnumerable<string> EnumerateFilesRecursive(string root,string pattern="*")
	{
		var todo = new Queue<string>();
		todo.Enqueue(root);
		while (todo.Count > 0)
		{
			string dir = todo.Dequeue();
			string[] subdirs = new string[0];
			string[] files = new string[0];
			try
			{
				subdirs = Directory.GetDirectories(dir);
				files = Directory.GetFiles(dir, pattern);
			}
			catch (IOException)
			{
			}
			catch (System.UnauthorizedAccessException)
			{
			}
			foreach (string subdir in subdirs)
			{
				todo.Enqueue(subdir);
			}
			foreach (string filename in files)
			{
				yield return filename;
			}
		}
	}
