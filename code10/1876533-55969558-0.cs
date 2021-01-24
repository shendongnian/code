    var plainText = "1y7wpc4iddseyrwez1lor8ow3297t.pd0bfl";
    var password = "rpsxi.t.rjsmklexarygfqyrrkhwdjh";
    var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    var passwordBytes = Encoding.UTF8.GetBytes(password).Take(8).ToArray();
    
    var des = new DESCryptoServiceProvider
    {
    	Mode = CipherMode.ECB
    };
    
    string encrypted = null;
    using (var desEncryptor = des.CreateEncryptor(passwordBytes, passwordBytes))
    {
    	var resultStream = new MemoryStream();
    	using (var cryptoStream = new CryptoStream(resultStream, desEncryptor, CryptoStreamMode.Write))
    	{
    		cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
    		cryptoStream.FlushFinalBlock();
    	}
    
    	encrypted = Convert.ToBase64String(resultStream.ToArray());
    }
