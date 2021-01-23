    AsymmetricKeyParameter privateKey;
    AsymmetricKeyParameter publicKey;
    AsymmetricKeyPair reconstitutedPair;
    certStream.Position = 0;
    pkcs8Stream.Position = 0;
    using (TextReader pkcs8reader = new StreamReader(pkcs8stream))
    {
        PemReader pemreader = new PemReader(pkcs8reader);
        var privateKey = pemreader.ReadObject() as ECPrivateKeyParameters;
        if (thisprivate == null)
            throw new GeneralSecurityException("failed to read private key");
        }
    }
    var certificate = new Org.BouncyCastle.X509.X509CertificateParser()
        .ReadCertificate(certStream);
    var publicKey = certificate.GetPublicKey();
    reconstitutedPair = new AsymmetricKeyPair(publicKey,privateKey);
    
