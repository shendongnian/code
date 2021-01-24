	[Test]
	public void TestEncryption()
	{
		/////////////// Create Key Files ////////////////
		string pubKeyLocation = Path.Combine(TestContext.CurrentContext.WorkDirectory,"pub");
		string privateKeyLocation = Path.Combine(TestContext.CurrentContext.WorkDirectory,"priv");
		RSACryptoServiceProvider provider = new RSACryptoServiceProvider(4096);
		
		//Create the key files on disk and distribute them to sender / reciever
		RSAParameters publicKey =  provider.ExportParameters(false);
		RSAParameters privateKey =  provider.ExportParameters(true);
		
		var serializer = new XmlSerializer(typeof(RSAParameters));
		
		using (var stream = File.Create(pubKeyLocation))
			serializer.Serialize(stream, publicKey);
		using (var stream = File.Create(privateKeyLocation))
			serializer.Serialize(stream, privateKey);
		/////////////// Actual Test ////////////////
		//send with the public key
		byte[] sent = Send("hey",pubKeyLocation);
		//cannot receive with public key
		var ex = Assert.Throws<CryptographicException>(()=>Receive(sent, pubKeyLocation));
		StringAssert.Contains("Key does not exist",ex.Message);
		//but can with private key
		Assert.AreEqual("hey", Receive(sent,privateKeyLocation));
	}
		private Byte[] Send(string send, string pubKeyLocation)
	{
		RSAParameters publicKey;
		
		var serializer = new XmlSerializer(typeof(RSAParameters));
		using (RSACryptoServiceProvider rsaSender = new RSACryptoServiceProvider())
		{
			using (var fs = new FileStream(pubKeyLocation, FileMode.Open))
				publicKey = (RSAParameters) serializer.Deserialize(fs);
			
			rsaSender.ImportParameters(publicKey);
			return rsaSender.Encrypt(Encoding.ASCII.GetBytes(send), false);
		}
	}
	
	private object Receive(byte[] sent, string privateKeyLocation)
	{
		RSAParameters privateKey;
		var serializer = new XmlSerializer(typeof(RSAParameters));
		using (RSACryptoServiceProvider rsaReceiver = new RSACryptoServiceProvider())
		{
			using (var fs = new FileStream(privateKeyLocation, FileMode.Open))
				privateKey = (RSAParameters) serializer.Deserialize(fs);
			
			rsaReceiver.ImportParameters(privateKey);
			return Encoding.ASCII.GetString(rsaReceiver.Decrypt(sent, false));
		}
	}
