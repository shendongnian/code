public static string DecryptAESStringFromBytes(byte[] encryptedText, byte[] key)
{
	// Check arguments.
	if ((encryptedText == null || encryptedText.Length <= 0) || (key == null || key.Length <= 0))
	{
		throw new ArgumentNullException("Missing arguments");
	}
	string decryptedText = null;
	// Create an AES object with the specified key and IV.
	using (AesManaged aesFactory = new AesManaged())
	{
		aesFactory.KeySize = 128;
		aesFactory.Key = AESCreateKey(key, aesFactory.KeySize / 8);
		aesFactory.IV = new byte[16];
		aesFactory.BlockSize = 128;
		aesFactory.Mode = CipherMode.ECB;
		aesFactory.Padding = PaddingMode.Zeros;
		// Create a decryptor to perform the stream transform.
		ICryptoTransform decryptor = aesFactory.CreateDecryptor();
		// Create the streams used for decryption.
		using (MemoryStream stream = new MemoryStream())
		{
			using (CryptoStream decryptStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
			{
				decryptStream.Write(encryptedText, 0, encryptedText.Length);
			}
			decryptedText = Encoding.Default.GetString(stream.ToArray());
		}
	}
	return decryptedText.Trim();
}
public static byte[] AESCreateKey(byte[] key, int keyLength)
{
	// Create the real key with the given key length.
	byte[] realkey = new byte[keyLength];
	// XOR each byte of the Key given with the real key until there's nothing left.
	// This allows for keys longer than our Key Length and pads short keys to the required length. 
	for (int i = 0; i < key.Length; i++)
	{
		realkey[i % keyLength] ^= key[i];
	}
	return realkey;
}
