 c
mbedtls_ecdh_init(...);
mbedtls_ecdh_setup(...);
mbedtls_ecdh_make_public(...); //make own public key and send it to peer
mbedtls_ecdh_read_public(...); //reed peers public key
mbedtls_ecdh_calc_secret(...); //note: i pass in my own RND func because of no OS
mbedtls_ecdh_free(...);
2. SHA256
 c
mbedtls_sha256_init(...);
mbedtls_sha256_starts_ret(...);
mbedtls_sha256_update_ret(...);
mbedtls_sha256_finish_ret(...);
mbedtls_sha256_free(...);
**C# side:**
 c#
private void EllipticCurveDiffieHellman()
{
    var ecdh = new ECDiffieHellmanCng(ECCurve.NamedCurves.brainpoolP256r1);
    ecdh.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
    ecdh.HashAlgorithm = CngAlgorithm.Sha256;
            
    //get relevant point from own public key
    var ownPublicKey = ecdh.PublicKey.ExportExplicitParameters().Q;
    var peersPublicKey = SendPublicKey(ownPublicKey); //key exchange
    var sharedSecret = ecdh.DeriveKeyMaterial(peersPublicKey);
    Console.WriteLine("Key: " + HexValue.Parse(sharedSecret.ToArray()));
}
DiffieHellmanPublicKey ToPublicKey(byte[] publicKey)
{
    var keyLength = 32;
    if (publicKey[0] != (2 + 2 * keyLength) - 1)
        throw new ArgumentException("Invalid key length", nameof(publicKey));
    if (publicKey[1] != 0x04)
        throw new ArgumentException("Invalid key format", nameof(publicKey));
    var parameters = new ECParameters()
    {
        Curve = ECCurve.NamedCurves.brainpoolP256r1,
        Q = new ECPoint()
        {
            X = publicKey.Skip(2).Take(keyLength).ToArray(),
            Y = publicKey.Skip(2 + keyLength).Take(keyLength).ToArray()
        }
    };
    using (var tmp = ECDiffieHellman.Create(parameters))
    {
        return tmp.PublicKey;
    }
}
