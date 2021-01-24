	[Test]
	public void TestEncryption()
	{
		/////////////// Create Key Files ////////////////
		RSACryptoServiceProvider provider = new RSACryptoServiceProvider(4096);
		//Create the key files on disk and distribute them to sender / reciever
		var publicKey =  provider.ToXmlString(false);
		var privateKey =  provider.ToXmlString(true);
				
		/////////////// Actual Test ////////////////
		//send with the public key
		byte[] sent = Send("hey",publicKey);
		//cannot receive with public key
		var ex = Assert.Throws<CryptographicException>(()=>Receive(sent, publicKey));
		StringAssert.Contains("Key does not exist",ex.Message);
		//but can with private key
		Assert.AreEqual("hey", Receive(sent,privateKey));
	}
	private Byte[] Send(string send, string publicKey)
	{
		using (RSACryptoServiceProvider rsaSender = new RSACryptoServiceProvider())
		{
			rsaSender.FromXmlString(publicKey);
			return rsaSender.Encrypt(Encoding.ASCII.GetBytes(send), false);
		}
	}
	private object Receive(byte[] sent, string privateKey)
	{
		using (RSACryptoServiceProvider rsaReceiver = new RSACryptoServiceProvider())
		{
			rsaReceiver.FromXmlString(privateKey);
			return Encoding.ASCII.GetString(rsaReceiver.Decrypt(sent, false));
		}
	}
