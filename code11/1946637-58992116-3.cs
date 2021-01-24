	public CryptoStream CreateStream(string inputFile, string password)
	{
		byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
		byte[] salt = new byte[32];
	
		FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
		fsCrypt.Read(salt, 0, salt.Length);
	
		RijndaelManaged AES = new RijndaelManaged();
		AES.KeySize = 256;
		AES.BlockSize = 128;
		var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
		AES.Key = key.GetBytes(AES.KeySize / 8);
		AES.IV = key.GetBytes(AES.BlockSize / 8);
		AES.Padding = PaddingMode.PKCS7;
		AES.Mode = CipherMode.CFB;
		
		return new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read, false);
	}
	
