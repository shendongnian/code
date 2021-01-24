	static string Decrypt(byte[] cipher, byte[] Key, byte[] IV)
	{
		string plaintext = null;
		using (RijndaelManaged rijndael = new RijndaelManaged())
		{
			rijndael.Key = Key;
			rijndael.IV = IV;
			ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
			using (var memoryStream = new MemoryStream(cipher))
			{
				using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
				{
					using (var streamReader = new StreamReader(cryptoStream))
					{
						plaintext = streamReader.ReadToEnd();
					}
				}
			}
		}
		return plaintext;
	}
