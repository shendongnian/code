		[Test]
		public void RsaEncryptDecryptDemo()
		{
			const string str = "Test";
			var rsa = new RSACryptoServiceProvider();
			var encodedData = rsa.Encrypt(Encoding.UTF8.GetBytes(str), false);
			var encodedString = Convert.ToBase64String(encodedData);
			var decodedData = rsa.Decrypt(Convert.FromBase64String(encodedString), false);
			var decodedStr = Encoding.UTF8.GetString(decodedData);
			
			Assert.AreEqual(str, decodedStr);
		}
