    void Main()
    {
	    foreach(var f in GetFilesToProcess("c:\\", new[] {"xml", "txt"}))
	        Debug.WriteLine(f);
    }
    private static IEnumerable<string> GetFilesToProcess(string path, IEnumerable<string> extensions)
    {
       return Directory.GetFiles(path, "*.*")
           .Where(f => extensions.Contains(f.Split('.').Last().ToLower()));
    }
