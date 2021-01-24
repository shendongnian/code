    X509SignatureGenerator dsaGen = new DSAX509SignatureGenerator(dsaCsp);
    // Use SHA-1 because that's all DSACryptoServiceProvider understands.
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA1;
    CertificateRequest request = new CertificateRequest(
        new X500DistinguishedName($"CN={KeyName}-{provType}"),
        dsaGen.PublicKey,
        hashAlgorithm);
    DateTimeOffset now = DateTimeOffset.UtcNow;
    using (X509Certificate2 cert = request.Create(request.SubjectName, dsaGen, now, now.AddDays(1), new byte[1]))
    using (X509Certificate2 certWithPrivateKey = cert.CopyWithPrivateKey(dsaCsp))
    using (DSA dsa = certWithPrivateKey.GetDSAPrivateKey())
    {
        byte[] signature = dsa.SignData(Array.Empty<byte>(), hashAlgorithm);
        Assert.True(dsaCsp.VerifyData(Array.Empty<byte>(), signature, hashAlgorithm));
    }
