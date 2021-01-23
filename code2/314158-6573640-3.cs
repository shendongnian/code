    public byte[] encryptData(byte[] data, out byte[] encryptedAesKey, out byte[] aesIV) {
    	if (data == null)
    		throw new ArgumentNullException("data");
    
    	byte[] encryptedData; // data to return
    
    	// begin AES key generation
    	RijndaelManaged aesAlg = new RijndaelManaged();
    	aesAlg.KeySize = AES_KEY_SIZE;
    	aesAlg.GenerateKey();
    	aesAlg.GenerateIV();
    	aesAlg.Mode = CipherMode.CBC;
    	aesAlg.Padding = PaddingMode.PKCS7;
    
    	// aes Key to be encrypted
    	byte[] aesKey = aesAlg.Key;
    
    	// aes IV that is passed back by reference
    	aesIV = aesAlg.IV;
    
        //get a new RSA crypto service provider to encrypt the AES key with the certificates public key
        using (RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider())
        {
            //add the certificates public key to the RSA crypto provider
            rsaCSP.FromXmlString(encryptionCertificate.PublicKey.Key.ToXmlString(false));
    
            //encrypt AES key with RSA Public key
            //passed back by reference
            encryptedAesKey = rsaCSP.Encrypt(aesKey, false);
    
            //get an aes encryptor instance
            ICryptoTransform aesEncryptor = aesAlg.CreateEncryptor();
    
            encryptedData = encryptWithAes(aesEncryptor, data);
        }
    	
    	if (encryptedData == null)
    		throw new CryptographicException(
    				"Fatal error while encrypting with AES");
    
    	return encryptedData;
    }
    
    private byte[] encryptWithAes(ICryptoTransform aesEncryptor, byte[] data) {
    	MemoryStream memStream = null; // stream to write encrypted data to
    	CryptoStream cryptoStream = null; // crypto stream to encrypted data
    
    	try {
    		memStream = new MemoryStream();
    
    		// initiate crypto stream telling it to write the encrypted data to
    		// the memory stream
    		cryptoStream = new CryptoStream(memStream, aesEncryptor,
    				CryptoStreamMode.Write);
    
    		// write the data to the memory stream
    		cryptoStream.Write(data, 0, data.Length);
    	} catch (Exception ee) {
    		// rethrow
    		throw new Exception("Error while encrypting with AES: ", ee);
    	} finally {
    		// close 'em
    		if (cryptoStream != null)
    			cryptoStream.Close();
    		if (memStream != null)
    			memStream.Close();
    	}
    
    	// return the encrypted data
    	return memStream.ToArray();
    }
