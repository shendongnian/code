public static byte[] SignDataSHA1(byte[] data, AsymmetricKeyParameter privateKey)
{
    // Converting bouncy castle key to native csp.
    RSAParameters rsaParam = DotNetUtilities.ToRSAParameters(privateKey as RsaPrivateCrtKeyParameters);
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    {
        rsa.ImportParameters(rsaParam);
        // Signing data.
        return rsa.SignHash(data, CryptoConfig.MapNameToOID("SHA1"));
    }
}
I basically just tell the signer that the data already hashed and voila, it worked.
