    // PKCS#1 doesn't say that this structure is always DER encoded, so read it as BER
    AsnReader reader = new AsnReader(data, AsnEncodingRules.BER);
    // RSAPrivateKey ::= SEQUENCE {
    AsnReader contents = reader.ReadSequence();
    // version Version (0 for two-prime RSA)
    if (!contents.TryReadInt32(out int version) || version != 0)
    {
        throw new CryptographicException();
    }
    // modulus INTEGER,
    BigInteger modulus = contents.ReadInteger();
    // publicExponent INTEGER,
    BigInteger publicExponent = contents.ReadInteger();
    // privateExponent INTEGER,
    BigInteger privateExponent = contents.ReadInteger();
    // prime1 INTEGER,
    BigInteger prime1 = contents.ReadInteger();
    // prime2 INTEGER,
    BigInteger prime2 = contents.ReadInteger();
    // exponent1 INTEGER,
    BigInteger exponent1 = contents.ReadInteger();
    // exponent2 INTEGER,
    BigInteger exponent2 = contents.ReadInteger();
    // coefficient INTEGER,
    BigInteger coefficient = contents.ReadInteger();
    // otherPrimeInfos OtherPrimeInfos OPTIONAL,
    // we don't support this, we limited to version 0.
    // good thing the next token is:
    // }
    contents.ThrowIfNotEmpty();
    // All done.
    // If you expected no trailing data:
    reader.ThrowIfNotEmpty();
