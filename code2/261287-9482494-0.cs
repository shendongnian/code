    // Initialize the following with your information
    var serial = 1234;
    var issuer = new X509Name("issuer");
    var subject = new X509Name("subject");
    // Creates the key pair
    var rsa = new RSA();
    rsa.GenerateKeys(1024, 0x10001, null, null);
    
    // Creates the certificate
    var key = new CryptoKey(rsa);
    var cert = new X509Certificate(serial, subject, issuer, key, DateTime.Now, DateTime.Now.AddYears(20));
    // Dumps the certificate into a .cer file
    var bio = BIO.File("C:/temp/cert.cer", "w");
    cert.Write(bio);
