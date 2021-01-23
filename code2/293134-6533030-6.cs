    public static string Encode(string input, byte[] key)
    {
    	byte[] byteArray = Encoding.ASCII.GetBytes(input);
    	using(var myhmacsha1 = new HMACSHA1(key))
    	{
    		var hashArray = myhmacsha1.ComputeHash(byteArray);
    		return hashArray.Aggregate("", (s, e) => s + String.Format("{0:x2}",e), s => s );
    	}
    }
