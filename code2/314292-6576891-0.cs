    [SecuritySafeCritical]
    public static string[] ReadAllLines(string path)
    {
	if (path == null)
	{
		throw new ArgumentNullException("path");
	}
	if (path.Length == 0)
	{
		throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
	}
	return File.InternalReadAllLines(path, Encoding.UTF8);
    }
