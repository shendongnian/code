    public static RSAParameters LoadParametersFromFile(string fileName)
    {
        int provType = 1;
        string provName = "Microsoft Enhanced Cryptographic Provider v1.0"
              
        // Load key container name;
        StringBuilder containerName = new StringBuilder();
        using (var keyFile = File.OpenRead(fileName))
        {
            keyFile.Position = 0x28;
            int c;
            while ((c = keyFile.ReadByte()) != 0 && c !=-1) containerName.Append((char) c);
        }
        
        CspParameters csp = new CspParameters(provType, provName);
        csp.Flags = CspProviderFlags.UseMachineKeyStore; // set it accordingly
        csp.KeyContainerName = containerName.ToString();
        using (RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(csp))
        {
            RSAParameters loadedParams = rsaKey.ExportParameters(false);
            return loadedParams;
        }
    }
  
