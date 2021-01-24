	string original = "This is what would be encrypted!";
	using (RijndaelManaged myRijndael = new RijndaelManaged())
	{
		myRijndael.GenerateKey(); // this line generates key
		myRijndael.GenerateIV(); // this line generates initialization vektor
        // This line returns encrypted text
		byte[] encryptedBytes = Encrypt(original, myRijndael.Key, myRijndael.IV);
        
        // You can decrypt the encrypted text like so
		string decryptedString = Decrypt(encryptedBytes, myRijndael.Key, myRijndael.IV);
    }
