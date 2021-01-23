    var _cgen = new X509V3CertificateGenerator();
    _cgen.Reset();
    _cgen.SetNotBefore(DateTime.Now);
    _cgen.SetNotAfter(new DateTime(2999, 12, 31, 23, 59, 59, DateTimeKind.Utc));
    var DN = new X509Name("CN=Self Signed Certificate");
    _cgen.SetIssuerDN(DN);
    _cgen.SetSubjectDN(DN);
    _cgen.SetPublicKey(_keypair.Public);
    _cgen.SetSignatureAlgorithm(             // Can be anything ECDsaWith*
        Org.BouncyCastle.Asn1.X9.X9ObjectIdentifiers.ECDsaWithSha256.ToString());
    _cgen.SetSerialNumber(                   // Serial number collisions suck
         new Org.BouncyCastle.Math.BigInteger(
             8 * 8 - 1,                      // number of bits to generate
             _SecureRandomSingleton));       // source to generate from
    var _cert = _cgen.Generate(_keypair.Private);
    try
    {
        _cert.Verify(_keypair.Public);
    } catch (Org.BouncyCastle.Security.Certificates.CertificateException E)
    {
        // error-handling code for Verify failure
        // Ridiculous here because we know that _keypair is correct, but good practice
        // to ensure that your keypair is correct and intact
    }
    Stream certStream = new MemoryStream();
    TextWriter certWriter = new StreamWriter(certStream);
    var pemWriter = new Org.BouncyCastle.OpenSsl.PemWriter(certWriter);
    pemWriter.WriteObject(_cert);
    pemWriter.Writer.Flush();
