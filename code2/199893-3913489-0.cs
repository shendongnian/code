        public static byte[] Encrypt(string data, byte[] key, byte[] iv)
        {
			MemoryStream memoryStream = null;
			DESCryptoServiceProvider cryptograph = null;
			CryptoStream cryptoStream = null;
			StreamWriter streamWriter = null;
			try
			{
				memoryStream = new MemoryStream();
				cryptograph = new DESCryptoServiceProvider();
				cryptoStream = new CryptoStream(memoryStream, cryptograph.CreateEncryptor(key, iv), CryptoStreamMode.Write);
				memoryStream = null;
				streamWriter = new StreamWriter(cryptoStream);
				cryptoStream = null;
				streamWriter.Write(data);
				return memoryStream.ToArray();
			}
			finally
			{
				if (memoryStream != null)
					memoryStream.Dispose();
				if (cryptograph != null)
					cryptograph.Dispose();
				if (cryptoStream != null)
					cryptoStream.Dispose();
				if (streamWriter != null)
					streamWriter.Dispose();
			}
        }
