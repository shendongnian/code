	public static void MyMethod()
	{
		String[] files = Directory.GetFiles("E:\\", "*.*");
		foreach (string file in files)
		{
			var fileN = file.Substring(2);
			string destfile = "E:\\2nd folder" + fileN;
			File.Copy(file, destfile, true);
		}
	}
