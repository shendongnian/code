    			byte[] dataKey = File.ReadAllBytes(fileName);
			Org.BouncyCastle.Crypto.AsymmetricKeyParameter asp =
				Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(pass.ToCharArray(), dataKey);
			MemoryStream ms = new MemoryStream();
			TextWriter writer = new StreamWriter(ms);
			System.IO.StringWriter stWrite = new System.IO.StringWriter();
			Org.BouncyCastle.OpenSsl.PemWriter pmw = new PemWriter(stWrite);
			pmw.WriteObject(asp);
			stWrite.Close();
			return stWrite.ToString();
