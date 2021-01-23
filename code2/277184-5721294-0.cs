		public static string CreateSHAHash(string Phrase)
		{
			SHA512Managed HashTool = new SHA512Managed();
			Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Phrase));
			Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
			HashTool.Clear();
			return Convert.ToBase64String(EncryptedBytes);
		}
