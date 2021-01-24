    byte[] md5;
    byte[] sha1;
    using (HashAlgorithm hash = MD5.Create())
    {
        md5 = hash.ComputeHash(toBeSigned);
    }
    using (HashAlgorithm hash = SHA1.Create())
    {
        sha1 = hash.ComputeHash(toBeSigned);
    }
    byte[] all = md5.Concat(sha1).ToArray();
    CspKeyContainerInfo cspInfo = rsaCsp.CspKeyContainerInfo;
    CngProvider provider = new CngProvider(cspInfo.ProviderName);
    CngKeyOpenOptions options = CngKeyOpenOptions.None;
    if (cspInfo.MachineKeyStore)
    {
        options = CngKeyOpenOptions.MachineKey;
    }
    using (CngKey cngKey = CngKey.Open(cspInfo.KeyContainerName, provider, options))
    {
        return NCryptInterop.SignHashRaw(cngKey, all, rsaCsp.KeySize);
    }
