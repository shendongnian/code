    private static string[] InternalReadAllLines(string path, Encoding encoding)
    {
	List<string> list = new List<string>();
	using (StreamReader streamReader = new StreamReader(path, encoding))
	{
		string item;
		while ((item = streamReader.ReadLine()) != null)
		{
			list.Add(item);
		}
	}
	return list.ToArray();
    }
