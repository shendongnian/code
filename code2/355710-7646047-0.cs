	// ...
	string originalText = "HI WORLD";
	byte[] myMess = Encoding.UTF8.GetBytes(originalText);
	Console.WriteLine("Original text >> " + Encoding.UTF8.GetString(myMess));
	byte[] myEcnryptedMess = Cryptography.Encrypt(myMess, aesKey);
	Console.WriteLine("Encrypted text >> " + Encoding.UTF8.GetString(myEcnryptedMess));
	Console.WriteLine("Decrypted text >> " + Cryptography.Decrypt(myEcnryptedMess, aesKey));
