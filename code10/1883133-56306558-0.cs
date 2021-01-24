    public static AsymCryptoSystem CreateFrom(TpmPublic pubKey, TpmPrivate privKey = null)
    {
        var cs = new AsymCryptoSystem();
    
        TpmAlgId keyAlgId = pubKey.type;
        cs.PublicParms = pubKey.Copy();
    
        // Create an algorithm provider from the provided PubKey
        switch (keyAlgId)
        {
            case TpmAlgId.Rsa:
                {
                    RawRsa rr = null;
                    byte[] prime1 = null,
                            prime2 = null;
                    if (privKey != null)
                    {
                        rr = new RawRsa(pubKey, privKey);
                        prime1 = RawRsa.ToBigEndian(rr.P);
                        prime2 = RawRsa.ToBigEndian(rr.Q);
                    }
                    var rsaParams = (RsaParms)pubKey.parameters;
                    var exponent = rsaParams.exponent != 0
                                            ? Globs.HostToNet(rsaParams.exponent)
                                            : RsaParms.DefaultExponent;
                    var modulus = (pubKey.unique as Tpm2bPublicKeyRsa).buffer;
                    AsymmetricKeyAlgorithmProvider rsaProvider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaOaepSha256);
    
                    uint primeLen1 = 0, primeLen2 = 0;
                    // Compute the size of BCRYPT_RSAKEY_BLOB
                    int rsaKeySize = exponent.Length + modulus.Length + 24;
                    if (prime1 != null && prime1.Length > 0)
                    {
                        if (prime2 == null || prime2.Length == 0)
                        {
                            Globs.Throw<ArgumentException>("LoadRSAKey(): The second prime is missing");
                            return null;
                        }
                        primeLen1 = (uint)prime1.Length;
                        primeLen2 = (uint)prime2.Length;
                        rsaKeySize += prime1.Length + prime2.Length;
                    }
                    else if (prime2 != null && prime2.Length > 0)
                    {
                        Globs.Throw<ArgumentException>("LoadRSAKey(): The first prime is missing");
                        return null;
                    }
    
                    var rsaKey = new byte[rsaKeySize];
    
                    // Initialize BCRYPT_RSAKEY_BLOB
                    int offset = 0;
                    WriteToBuffer(ref rsaKey, ref offset, primeLen1 == 0 ?
                                    BCRYPT_RSAPUBLIC_MAGIC : BCRYPT_RSAPRIVATE_MAGIC);
                    WriteToBuffer(ref rsaKey, ref offset, (uint)modulus.Length * 8);
                    WriteToBuffer(ref rsaKey, ref offset, (uint)exponent.Length);
                    WriteToBuffer(ref rsaKey, ref offset, (uint)modulus.Length);
                    WriteToBuffer(ref rsaKey, ref offset, primeLen1);
                    WriteToBuffer(ref rsaKey, ref offset, primeLen1);
                    WriteToBuffer(ref rsaKey, ref offset, exponent);
                    WriteToBuffer(ref rsaKey, ref offset, modulus);
                    if (primeLen1 != 0)
                    {
                        WriteToBuffer(ref rsaKey, ref offset, prime1);
                        WriteToBuffer(ref rsaKey, ref offset, prime2);
                    }
    
                    IBuffer rsaBuffer = CryptographicBuffer.CreateFromByteArray(rsaKey);
    
                    if (primeLen1 == 0)
                    {
                        cs.Key = rsaProvider.ImportPublicKey(rsaBuffer, CryptographicPublicKeyBlobType.BCryptPublicKey);
                    }
                    else
                    {
                        cs.Key = rsaProvider.ImportKeyPair(rsaBuffer, CryptographicPrivateKeyBlobType.BCryptPrivateKey);
                    }
                    break;
                }
            case TpmAlgId.Ecc:
                {
                    var eccParms = (EccParms)pubKey.parameters;
                    var eccPub = (EccPoint)pubKey.unique;
                    var algId = RawEccKey.GetEccAlg(pubKey);
                    if (algId == null)
                    {
                        return null;
                    }
                    bool isEcdsa = eccParms.scheme.GetUnionSelector() == TpmAlgId.Ecdsa;
                    byte[] keyBlob = RawEccKey.GetKeyBlob(eccPub.x, eccPub.y, keyAlgId,
                                                            !isEcdsa, eccParms.curveID);
                    AsymmetricKeyAlgorithmProvider eccProvider = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(algId);
                    cs.Key = eccProvider.ImportKeyPair(CryptographicBuffer.CreateFromByteArray(keyBlob));
                    break;
                }
            default:
                Globs.Throw<ArgumentException>("Algorithm not supported");
                cs = null;
                break;
        }
        return cs;
    }
