    public static string ReadAllText(string path)
    {
    	if (path == null)
    	{
    		throw new ArgumentNullException("path");
    	}
    	if (path.Length == 0)
    	{
    		throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
    	}
    	return File.InternalReadAllText(path, Encoding.UTF8);
    }   
    private static string InternalReadAllText(string path, Encoding encoding)
    {
    	string result;
    	using (StreamReader streamReader = new StreamReader(path, encoding))
    	{
    		result = streamReader.ReadToEnd();
    	}
    	return result;
    }
