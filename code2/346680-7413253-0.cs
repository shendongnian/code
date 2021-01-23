	List<SomeObject> GetAllVersions(byte[] bytes)
	{
		var result = new List<SomeObject>();
		foreach (byte b in bytes)
		{
			result.Add(GetVersion(b));
		}
		return result;
	}
