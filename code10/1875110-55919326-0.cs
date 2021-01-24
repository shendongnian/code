    static void Main(string[] args)
    {
        var cert = GenerateCertificate("localhost");
    
        byte[] ciphertext = Encrypt(Encoding.ASCII.GetBytes("Hello world!"), cert);
        byte[] plaintext = Decrypt(ciphertext, cert);
    
        Console.WriteLine(Encoding.ASCII.GetString(plaintext));
    }
    
    static X509Certificate2 GenerateCertificate(string certName)
    {
        var secureRandom = new SecureRandom(new CryptoApiRandomGenerator());
        var keypairgen = new RsaKeyPairGenerator();
        // RSA key size = 1024 bits
        keypairgen.Init(new KeyGenerationParameters(secureRandom, 1024));
    
        var keypair = keypairgen.GenerateKeyPair();
    
        var gen = new X509V3CertificateGenerator();
        // we will use SHA256 signature
        var signatureFactory = new Asn1SignatureFactory("SHA256WITHRSA", keypair.Private, secureRandom);
    
        var CN = new X509Name("CN=" + certName);
        var SN = BigInteger.ProbablePrime(120, new Random());
    
        gen.SetSerialNumber(SN);
        gen.SetSubjectDN(CN);
        gen.SetIssuerDN(CN);
        gen.SetNotAfter(DateTime.MaxValue);
        gen.SetNotBefore(DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));
        gen.SetPublicKey(keypair.Public);
    
        var newCert = gen.Generate(signatureFactory);
    
        var x509cert = new X509Certificate2(DotNetUtilities.ToX509Certificate(newCert));
        var rsa = RSA.Create();
        var publicKey = (RsaKeyParameters)keypair.Public;
        var privateKey = (RsaPrivateCrtKeyParameters)keypair.Private;
        var parameters = new RSAParameters
        {
            Modulus = publicKey.Modulus.ToByteArrayUnsigned(),
            Exponent = publicKey.Exponent.ToByteArrayUnsigned(),
            P = privateKey.P.ToByteArrayUnsigned(),
            Q = privateKey.Q.ToByteArrayUnsigned(),
            DP = privateKey.DP.ToByteArrayUnsigned(),
            DQ = privateKey.DQ.ToByteArrayUnsigned(),
            InverseQ = privateKey.QInv.ToByteArrayUnsigned(),
            D = privateKey.Exponent.ToByteArrayUnsigned(),
        };
        rsa.ImportParameters(parameters);
        // at this point X509Certificate2 will check if PrivateKey matches PublicKey
        x509cert.PrivateKey = rsa;
    
        return x509cert;
    }
    
    public static byte[] Encrypt(byte[] plainBytes, X509Certificate2 cert)
    {
        RSACryptoServiceProvider publicKey = (RSACryptoServiceProvider)cert.PublicKey.Key;
        byte[] encryptedBytes = publicKey.Encrypt(plainBytes, false);
        return encryptedBytes;
    }
    
    public static byte[] Decrypt(byte[] encryptedBytes, X509Certificate2 cert)
    {
        RSACryptoServiceProvider privateKey = (RSACryptoServiceProvider)cert.PrivateKey;
        byte[] decryptedBytes = privateKey.Decrypt(encryptedBytes, false);
        return decryptedBytes;
    }
