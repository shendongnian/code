    private static System.Security.Cryptography.HashAlgorithm GetHashAlgorithm(System.Security.Cryptography.HashAlgorithmName hashAlgorithmName)
    {
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.MD5)
            return (System.Security.Cryptography.HashAlgorithm) System.Security.Cryptography.MD5.Create();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA1)
            return (System.Security.Cryptography.HashAlgorithm) System.Security.Cryptography.SHA1.Create();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA256)
            return (System.Security.Cryptography.HashAlgorithm) System.Security.Cryptography.SHA256.Create();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA384)
            return (System.Security.Cryptography.HashAlgorithm) System.Security.Cryptography.SHA384.Create();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA512)
            return (System.Security.Cryptography.HashAlgorithm) System.Security.Cryptography.SHA512.Create();
        throw new System.Security.Cryptography.CryptographicException($"Unknown hash algorithm \"{hashAlgorithmName.Name}\".");
    }
    
    protected override byte[] HashData(System.IO.Stream data,
        System.Security.Cryptography.HashAlgorithmName hashAlgorithm)
    {
        using (System.Security.Cryptography.HashAlgorithm hashAlgorithm1 = 
        GetHashAlgorithm(hashAlgorithm))
        return hashAlgorithm1.ComputeHash(data);
    }
