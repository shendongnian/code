    // publicKeyX509PEM: String containig the key-data
    byte[] publicKeyX509DER = ConvertX509PemToDer(publicKeyX509PEM);
    RSA rsa = RSA.Create();
    rsa.ImportSubjectPublicKeyInfo(publicKeyX509DER, out _);
    RSAParameters parameters = rsa.ExportParameters(false);
    // get parameters.Exponent and parameters.Modulus
