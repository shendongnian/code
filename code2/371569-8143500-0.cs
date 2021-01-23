    Try this code snip out
    
    bool chainIsValid = false;
    
    var chain = new X509Chain();
    
    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
    
    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
    
    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
    
    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
    
    chainIsValid = chain.Build(certificate);
