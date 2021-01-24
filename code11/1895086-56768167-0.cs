    public string Encrypt(string message, string secret)
    {
    	var encoding = new System.Text.UTF8Encoding();
    	var keyBytes = encoding.GetBytes(secret);
    	var messageBytes = encoding.GetBytes(message);
    	using (var hmacsha1 = new HMACSHA1(keyBytes))
    	{
    		var hashMessage = hmacsha1.ComputeHash(messageBytes);
    		return Convert.ToBase64String(hashMessage);
    	}
    }
