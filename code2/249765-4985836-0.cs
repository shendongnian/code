    CspParameters parms = new CspParameters();
    parms.Flags = CspProviderFlags.NoFlags;
    parms.KeyContainerName = "CLR{37FE3D13-EEE5-4939-93BC-3E1C605BF3BA}";
    parms.ProviderType = 1;
    
    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(parms);
