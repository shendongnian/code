            // Convert BouncyCastle X509 Certificate to .NET's X509Certificate
            var cert = DotNetUtilities.ToX509Certificate(certificate);
            var certBytes = cert.Export(X509ContentType.Pkcs12, "password");
            // Convert X509Certificate to X509Certificate2
            var cert2 = new X509Certificate2(certBytes, "password");
            // Convert BouncyCastle Private Key to RSA
            var rsaPriv = DotNetUtilities.ToRSA(issuerKeyPair.Private as RsaPrivateCrtKeyParameters);
            // Setup RSACryptoServiceProvider with "KeyContainerName" set
            var csp = new CspParameters();
            csp.KeyContainerName = "KeyContainer";
            var rsaPrivate = new RSACryptoServiceProvider(csp);
            // Import private key from BouncyCastle's rsa
            rsaPrivate.ImportParameters(rsaPriv.ExportParameters(true));
            // Set private key on our X509Certificate2
            cert2.PrivateKey = rsaPrivate;
            // Export Certificate with private key
            File.WriteAllBytes(@"C:\Temp\cert.pfx", cert2.Export(X509ContentType.Pkcs12, "password"));
