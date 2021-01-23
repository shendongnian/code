            public void GetCertificate() {
            
            // Get the Machine Cert Store
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            string alg = CryptoConfig.MapNameToOID("SHA512");
            // Open the cert store
            store.Open(OpenFlags.ReadWrite);
            // Loop through each certificate within the store
            foreach (X509Certificate2 myCert in store.Certificates)
            {
                // Get the certificate we are looking for
                if (myCert.IssuerName.Name.Contains("CN=YourSite"))
                {
                    // Check if the certificate has a private key
                    if (myCert.HasPrivateKey)
                    {
                        // Get your custom signature as a string
                        string mySignature = GetSignatureString();
                        // Convert signature to byte array
                        byte[] originalData = Encoding.UTF8.GetBytes(mySignature);
                        // Create RSA provider from private key
                        RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider)myCert.PrivateKey;
                        // Sign the signature with SHA512
                        byte[] signedSignature = signedSignature = rsaProvider.SignData(originalData, alg);
                        if (rsaProvider.VerifyData(originalData, alg, signedSignature))
                        {
                            // Signature is verified Do Stuff
                        }
                        else
                        {
                            throw new Exception("The data does not match the signature.");
                        }
                    }
                }
            }
        }
