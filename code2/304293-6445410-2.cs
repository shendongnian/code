            AsymmetricCipherKeyPair	signaturePair;
			X509Certificate signatureCert;
			IList certList = new ArrayList();
			IList crlList = new ArrayList();
			CmsProcessable msg = new CmsProcessableByteArray(Encoding.ASCII.GetBytes("I hate hello world!"));
			certList.Add(signatureCert);
			certList.Add(OrigCert);
			crlList.Add(SignCrl);
			IX509Store x509Certs = X509StoreFactory.Create(
				"Certificate/Collection",
				new X509CollectionStoreParameters(certList));
			IX509Store x509Crls = X509StoreFactory.Create(
				"CRL/Collection",
				new X509CollectionStoreParameters(crlList));
			CmsSignedDataGenerator gen = new CmsSignedDataGenerator();
			gen.AddSigner(signaturePair.Private, signatureCert, CmsSignedDataGenerator.DigestSha1);
			gen.AddCertificates(x509Certs);
			gen.AddCrls(x509Crls);
			CmsSignedData signedData = gen.Generate(msg, true);
            
            //saving in BER encoding
            Stream stream = new MemoryStream(signedData.GetEncoded());
