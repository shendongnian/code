    private static Org.BouncyCastle.Crypto.IDigest GetBouncyAlgorithm(
        System.Security.Cryptography.HashAlgorithmName hashAlgorithmName)
    {
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.MD5)
            return new Org.BouncyCastle.Crypto.Digests.MD5Digest();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA1)
            return new Org.BouncyCastle.Crypto.Digests.Sha1Digest();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA256)
            return new Org.BouncyCastle.Crypto.Digests.Sha256Digest();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA384)
            return new Org.BouncyCastle.Crypto.Digests.Sha384Digest();
        if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA512)
            return new Org.BouncyCastle.Crypto.Digests.Sha512Digest();
        
        throw new System.Security.Cryptography.CryptographicException(
            $"Unknown hash algorithm \"{hashAlgorithmName.Name}\"."
        );
    } // End Function GetBouncyAlgorithm  
    
    protected override byte[] HashData(System.IO.Stream data,
        System.Security.Cryptography.HashAlgorithmName hashAlgorithm)
    {
        Org.BouncyCastle.Crypto.IDigest digest = GetBouncyAlgorithm(hashAlgorithm);
        
        byte[] buffer = new byte[4096];
        int cbSize;
        while ((cbSize = data.Read(buffer, 0, buffer.Length)) > 0)
            digest.BlockUpdate(buffer, 0, cbSize);
        
        byte[] hash = new byte[digest.GetDigestSize()];
        digest.DoFinal(hash, 0);
        return hash;
    }
    
