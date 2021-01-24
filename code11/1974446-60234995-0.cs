    public static string GenerateSHA256(string input)
    {
    	var bytes = Encoding.Unicode.GetBytes(input);
    	using (var hashEngine = SHA256.Create())
    	{
    		var hashedBytes = hashEngine.ComputeHash(bytes, 0, bytes.Length);
    		var sb = new StringBuilder();
    		foreach (var b in hashedBytes)
    		{
    			var hex = b.ToString("x2");
    			sb.Append(hex);
    		}
    		return sb.ToString();
    	}
    }
