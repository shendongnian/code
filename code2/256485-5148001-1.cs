    var chain = new X509Chain();
    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(1000);
    chain.ChainPolicy.VerificationTime = DateTime.Now;
    var elementValid = chain.Build (x509certificate);
