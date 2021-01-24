    System.Security.Cryptography.CspParameters csp = new CspParameters();
    csp.KeyContainerName = "MyKeyName";
    csp.Flags = CspProviderFlags.UseMachineKeyStore;
    
    System.Security.Cryptography.RSACryptoServiceProvider key = new RSACryptoServiceProvider(csp);
