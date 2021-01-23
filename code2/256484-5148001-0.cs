    var chain = new X509Chain();
    chain.Build (x509certificate);
    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(1000);
    chain.ChainPolicy.VerificationTime = DateTime.Now;
    foreach (var element in chain.ChainElements)
    {
       var elementValid = element.Certificate.Verify();
    }
