    var plainText = "1y7wpc4iddseyrwez1lor8ow3297t.pd0bfl";
    var password = "rpsxi.t.rjsmklexarygfqyrrkhwdjh";
    var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    var passwordBytes = Encoding.UTF8.GetBytes(password).Take(8).ToArray();
    
    var des = new DESCryptoServiceProvider
    {
    	Mode = CipherMode.CBC, // don't use ECB as your CipherMode
    	Padding = PaddingMode.PKCS7,
    	Key = passwordBytes
    };
    
    des.GenerateIV(); // work with a unique IV for each operation
    
    string encrypted = null;
    using (var desEncryptor = des.CreateEncryptor())
    {
    	var resultStream = new MemoryStream();
    	using (var cryptoStream = new CryptoStream(resultStream, desEncryptor, CryptoStreamMode.Write))
    	{
    		cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
    	}
    
    	encrypted = Convert.ToBase64String(resultStream.ToArray());
    }
