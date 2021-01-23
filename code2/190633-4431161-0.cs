    RSACryptoServiceProvider rsa = signingCertificate_GetPublicKey();
    return rsa.VerifyData( SignedValue(), CryptoConfig.MapNameToOID( "SHA1" ), Signature() );
    
    RSACryptoServiceProvider signingCertificate_GetPublicKey()
    {
        RSACryptoServiceProvider publicKey = new RSACryptoServiceProvider();
    
        RSAParameters publicKeyParams = new RSAParameters();
        publicKeyParams.Modulus = GetPublicKeyModulus();
        publicKeyParams.Exponent = GetPublicKeyExponent();
    
        publicKey.ImportParameters( publicKeyParams );
    
        return publicKey;
    }
    
    byte[] GetPublicKeyExponent()
    {
        // The value of the second TLV in your Public Key
    }
    
    byte[] GetPublicKeyModulus()
    {
        // The value of the first TLV in your Public Key
    }
    
    byte[] SignedValue()
    {
        // The first TLV in your Ceritificate
    }
    
    byte[] Signature()
    {
        // The value of the third TLV in your Certificate
    }
