    public string Decrypt(string cipherText)
    {
      if (string.IsNullOrEmpty(cipherText))
        return "";
      string result;
      Encoding byteEncoder = Encoding.Default;
      byte[] rijnKey = byteEncoder.GetBytes(Password);
      byte[] rijnIv = byteEncoder.GetBytes(InitialVector);
      RijndaelManaged rijn = new RijndaelManaged { Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
      using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
      {
        using (ICryptoTransform decryptor = rijn.CreateDecryptor(rijnKey, rijnIv))
        {
          using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
          {
						using (StreamReader swDecrypt = new StreamReader(csDecrypt))
						{
							result = swDecrypt.ReadToEnd();
						}
					}
        }
      }
      rijn.Clear();      
      return result.Replace("\0", "");
    }
