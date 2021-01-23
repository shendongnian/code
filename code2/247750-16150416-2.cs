    [TestMethod]
    public void TestCertificate()
    {
        const string publicCert = @"MIIBrzCCARigAwIBAgIQEkeKoXKDFEuzql5XQnkY9zANBgkqhkiG9w0BAQUFADAYMRYwFAYDVQQDEw1DZXJ0QXV0aG9yaXR5MB4XDTEzMDQxOTIwMDAwOFoXDTM5MTIzMTIzNTk1OVowFjEUMBIGA1UEAxMLc2VydmVyMS5jb20wgZ0wDQYJKoZIhvcNAQEBBQADgYsAMIGHAoGBAIEmC1/io4RNMPCpYanPakMYZGboMCrN6kqoIuSI1n0ufzCbwRkpUjJplsvRH9ijIHMKw8UVs0i0Ihn9EnTCxHgM7icB69u9EaikVBtfSGl4qUy5c5TZfbN0P3MmBq4YXo/vXvCDDVklsMFem57COAaVvAhv+oGv5oiqEJMXt+j3AgERMA0GCSqGSIb3DQEBBQUAA4GBAICWZ9/2zkiC1uAend3s2w0pGQSz4RQeh9+WiT4n3HMwBGjDUxAx73fhaKADMZTHuHT6+6Q4agnTnoSaU+Fet1syVVxjLeDHOb0i7o/IDUWoEvYATi8gCtcV20KxsQVLEc5jkkajzUc0eyg050KZaLzV+EkCKBafNoVFHoMCbm3n";
        const string privateCert = @"<RSAKeyValue><Modulus>gSYLX+KjhE0w8Klhqc9qQxhkZugwKs3qSqgi5IjWfS5/MJvBGSlSMmmWy9Ef2KMgcwrDxRWzSLQiGf0SdMLEeAzuJwHr270RqKRUG19IaXipTLlzlNl9s3Q/cyYGrhhej+9e8IMNWSWwwV6bnsI4BpW8CG/6ga/miKoQkxe36Pc=</Modulus><Exponent>EQ==</Exponent><P>mmRPs28vh0mOsnQOder5fsxKsuGhBkz+mApKTNQZkkn7Ak3CWKaFzCI3ZBZUpTJag841LL45uM2NvesFn/T25Q==</P><Q>1iTLW2zHVIYi+A6Pb0UarMaBvOnH0CTP7xMEtLZD5MFYtqG+u45mtFj1w49ez7n5tq8WyOs90Jq1qhnKGJ0mqw==</Q><DP>JFPWhJKhxXq4Kf0wlDdJw3tc3sutauTwnD6oEhPJyBFoPMcAjVRbt4+UkAVBF8+c07gMgv+VHGyZ0lVqvDmjgQ==</DP><DQ>lykIBEzI8F6vRa/sxwOaW9dqo3fYVrCSxuA/jp7Gg1tNrhfR7c3uJPOATc6dR1YZriE9QofvZhLaljBSa7o5aQ==</DQ><InverseQ>KrrKkN4IKqqhrcpZbYIWH4rWoCcnfTI5jxMfUDKUac+UFGNxHCUGLe1x+rwz4HcOA7bKVECyGe6C9xeiN3XKuQ==</InverseQ><D>Fsp6elUr6iu9V6Vrlm/lk16oTmU1rTNllLRCZJCeUlN/22bHuSVo27hHyZ1f+Q26bqeL9Zpq7rZgXvBsqzFt9tBOESrkr+uEHIZwQ1HIDw2ajxwOnlrj+zjn6EKshrMOsEXXbgSAi6SvGifRC2f+TKawt9lZmGElV4QgMYlC56k=</D></RSAKeyValue>";
 
        var certificate = new X509Certificate2(Convert.FromBase64String(publicCert));
 
        var crypto = new RSACryptoServiceProvider();
 
        crypto.FromXmlString(privateCert);
 
        certificate.PrivateKey = crypto;
 
        //export a private key
        var exportedPrivate = certificate.PrivateKey.ToXmlString(true);
        var exportedPublic = Convert.ToBase64String(certificate.RawData);
 
        Assert.AreEqual(publicCert, exportedPublic);
        Assert.AreEqual(privateCert, exportedPrivate);
     }
