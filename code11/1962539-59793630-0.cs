    var cp = new CspParameters{
        KeyContainerName = csp.CspKeyContainerInfo.KeyContainerName,
        KeyNumber = csp.CspKeyContainerInfo.KeyNumber == KeyNumber.Exchange ? 1 : 2,
        Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseExistingKey,
    };
