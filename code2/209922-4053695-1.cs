	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Decrypt(Encrypt("This is a sample", "thisismypassword"), "thisismypassword"));
		}
		public static string Encrypt(string plaintext, string password)
		{
			return Convert.ToBase64String((new AesManaged { Key = Encoding.UTF8.GetBytes(password), Mode = CipherMode.ECB  }).CreateEncryptor().TransformFinalBlock(Encoding.UTF8.GetBytes(plaintext), 0, Encoding.UTF8.GetBytes(plaintext).Length));
		}
		public static string Decrypt(string ciphertext, string password)
		{
			return Encoding.UTF8.GetString((new AesManaged { Key = Encoding.UTF8.GetBytes(password), Mode = CipherMode.ECB }).CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(ciphertext), 0, Convert.FromBase64String(ciphertext).Length));
		}
	}
