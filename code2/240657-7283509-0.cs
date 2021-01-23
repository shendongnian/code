    CspParameters cspParams;
    cspParams = new CspParameters(PROVIDER_RSA_FULL);
    cspParams.KeyContainerName = CONTAINER_NAME;
    cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
    cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
    
    CryptoKeyAccessRule rule = new CryptoKeyAccessRule("everyone", CryptoKeyRights.FullControl, AccessControlType.Allow);
    
    cspParams.CryptoKeySecurity = new CryptoKeySecurity();
    cspParams.CryptoKeySecurity.SetAccessRule(rule);
