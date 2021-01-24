    public byte[] SignData(byte[] data)
    {
        using (var sha256 = SHA256.Create())
    	{
    		using (var rsa = (RSACryptoServiceProvider) Certificate.PrivateKey)
    		{
    			return rsa.SignData(data, sha256);
    		}
    	}
    }
    
    public bool VerifySignature(byte[] data, byte[] signature)
    {
    	using (var sha256 = SHA256.Create())
    	{
    		using (var rsa = (RSACryptoServiceProvider) Certificate.PrivateKey)
    		{
    			return rsa.VerifyData(data, sha256, signature);
    		}
    	}
    }
