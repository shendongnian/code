    public string BinaryToString(string binary)
    {
    	if (string.IsNullOrEmpty(binary))
    		throw new ArgumentNullException("binary");
    
    	if ((binary.Length % 8) != 0)
    		throw new ArgumentException("Binary string invalid (must divide by 8)", "binary");
    
    	StringBuilder builder = new StringBuilder();
    	for (int i = 0; i < binary.Length; i += 8)
    	{
    		string section = binary.Substring(i, 8);
    		int ascii = 0;
    		try
    		{
    			ascii = Convert.ToInt32(section, 2);
    		}
    		catch
    		{
    			throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
    		}
    		builder.Append((char)ascii);
    	}
    	return builder.ToString();
    }
