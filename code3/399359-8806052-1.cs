    public static string SafeGetString(this SqlDataReader _Reader, int _ColIndex)
	{
		if (_Reader.IsDBNull(_ColIndex))
			return null; //Default value
		else
			return _Reader.GetString(_ColIndex);
	}
