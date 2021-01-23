    // Find my openssl-generated cert from the registry
    var store = new X509Store(StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    var certificates = store.Certificates.Find(X509FindType.FindBySubjectName, "myapp.com", true);
    var certificate = certificates[0];
    store.Close();
    // Note that this will return a Basic crypto provider, with only SHA-1 support
    var privKey = (RSACryptoServiceProvider)certificate.PrivateKey;
    // Force use of the Enhanced RSA and AES Cryptographic Provider with openssl-generated SHA256 keys
    var enhCsp = new RSACryptoServiceProvider().CspKeyContainerInfo;
    var cspparams = new CspParameters(enhCsp.ProviderType, enhCsp.ProviderName, privKey.CspKeyContainerInfo.KeyContainerName);
    privKey = new RSACryptoServiceProvider(cspparams);
