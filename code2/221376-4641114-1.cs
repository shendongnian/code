    public byte[] Decode(string str)
    {
    	var decbuff = Convert.FromBase64String(str);
    	return decbuff;
    }
    
    static public String DecryptRJ256(byte[] cypher, string KeyString, string IVString)
    {
    	var sRet = "";
    
    	var encoding = new UTF8Encoding();
    	var Key = encoding.GetBytes(KeyString);
    	var IV = encoding.GetBytes(IVString);
    
    	using (var rj = new RijndaelManaged())
    	{
    		try
    		{
    			rj.Padding = PaddingMode.PKCS7;
    			rj.Mode = CipherMode.CBC;
    			rj.KeySize = 256;
    			rj.BlockSize = 256;
    			rj.Key = Key;
    			rj.IV = IV;
    			var ms = new MemoryStream(cypher);
    
    			using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
    			{
    				using (var sr = new StreamReader(cs))
    				{
    					sRet = sr.ReadLine();
    				}
    			}
    		}
    		finally
    		{
    			rj.Clear();
    		}
    	}
    
    	return sRet;
    }
