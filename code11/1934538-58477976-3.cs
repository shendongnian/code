	static byte[] Encrypt(string input, byte[] Key, byte[] IV)
	{
		byte[] encryptedBytes;
		using (RijndaelManaged rijndael = new RijndaelManaged())
		{
			rijndael.Key = Key;
			rijndael.IV = IV;
			ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
			using (var memoryStream = new MemoryStream())
			{
				using (var cryptoStream = new CryptoStream(memoryStream,
						encryptor, CryptoStreamMode.Write))
				{
					using (var streamWriter = new StreamWriter(cryptoStream))
					{
						streamWriter.Write(input);
					}
					encryptedBytes = memoryStream.ToArray();
				}
			}
		}
		return encryptedBytes;
	}
