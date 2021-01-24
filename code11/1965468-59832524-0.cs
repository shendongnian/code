	internal int GetValueIndexCaseSensitive(string name)
	{
		for (int i = 0; i < _keys.Length; i++)
		{
			if (string.Equals(_keys[i], name, StringComparison.Ordinal))
			{
				return i;
			}
		}
		return -1;
	}
	
