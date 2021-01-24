    public string Sign(byte[] input, string privateKeyPath)
        {
			asymmetricKeyParameter AsymmetricKeyParameterFromPrivateKeyInPemFile
            // Sign the hash
            IBufferedCipher c = CipherUtilities.GetCipher("RSA//PKCS1Padding");
            c.Init(true, asymmetricKeyParameter);
            var outBytes = c.DoFinal(input);
            return Convert.ToBase64String(outBytes);
        }
		
		public AsymmetricKeyParameter AsymmetricKeyParameterFromPrivateKeyInPemFile(string privateKeyPath)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(privateKeyPath)))
            {
                PemReader pr = new PemReader(privateKeyTextReader);
                AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
                return keyPair.Private;
            }
        }
