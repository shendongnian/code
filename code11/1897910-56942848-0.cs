    var collection = new X509Certificate2Collection();
    collection.Import("test.pfx", "password");
    var chain = new X509Chain();
    chain.ChainPolicy.ExtraStore.AddRange(collection);
    // untrusted root error raise false-positive errors, for example RevocationOffline
    // so skip possible untrusted root chain error.
    chain.VerificationFlags |= X509VerificationFlags.AllowUnknownCertificateAuthority;
    // revocation checking is client's responsibility. Skip it.
    chain.RevocationMode = X509VerificationFlags.NoCheck;
    // build the chain.
    Boolean isValid = chain.Build(collection[0]);
    // explore chain.ChainElements collection. First item should be your leaf
    // certificate and last item should be root certificate
