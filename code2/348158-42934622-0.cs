            var certifiedRSACryptoServiceProvider = cert2.PrivateKey as RSACryptoServiceProvider;
            RSACryptoServiceProvider defaultRSACryptoServiceProvider = new RSACryptoServiceProvider();
            defaultRSACryptoServiceProvider.ImportParameters(certifiedRSACryptoServiceProvider.ExportParameters(true));
            byte[] signedHashValue = defaultRSACryptoServiceProvider.SignData(computedHash, "SHA256");
            string signature = Convert.ToBase64String(signedHashValue);
            Console.WriteLine("Signature : {0}", signature);
            RSACryptoServiceProvider publicCertifiedRSACryptoServiceProvider = cert2.PublicKey.Key as RSACryptoServiceProvider;
            bool verify = publicCertifiedRSACryptoServiceProvider.VerifyData(computedHash, "SHA256", signedHashValue);
            Console.WriteLine("Verification result : {0}", verify);
