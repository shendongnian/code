    namespace AppleBusinessChat45
    {
        class Program
        {
            static void Main(string[] args)
            {
                var privateKey = "pX/BvdXXUdpC79mW/jWi10Z6PJb5SBY2+aqkR/qYOjqgakKsqZFKnl0kz10Ve+BP";
                var token = "BDiRKNnPiPUb5oala31nkmCaXMB0iyWy3Q93p6fN7vPxEQSUlFVsInkJzPBBqmW1FUIY1KBA3BQb3W3Qv4akZ8kblqbmvupE/EJzPKbROZFBNvxpvVOHHgO2qadmHAjHSmnxUuxrpKxopWnOgyhzUx+mBUTao0pcEgqZFw0Y/qZIJPf1KusCMlz5TAhpjsw=";
    
                // #####
                // ##### Step 1
                // #####
                var decodedToken = Convert.FromBase64String(token);
                var decodedEphemeralPublicKey = decodedToken.Take(97).ToArray();
                var encodedEphemeralPublicKeyCheck = Convert.ToBase64String(decodedEphemeralPublicKey);
    
                if (encodedEphemeralPublicKeyCheck != "BDiRKNnPiPUb5oala31nkmCaXMB0iyWy3Q93p6fN7vPxEQSUlFVsInkJzPBBqmW1FUIY1KBA3BQb3W3Qv4akZ8kblqbmvupE/EJzPKbROZFBNvxpvVOHHgO2qadmHAjHSg==")
                    throw new Exception("Public key check failed");
    
                X9ECParameters curveParams = ECNamedCurveTable.GetByName("secp384r1");
                ECPoint decodePoint = curveParams.Curve.DecodePoint(decodedEphemeralPublicKey);
                ECDomainParameters domainParams = new ECDomainParameters(curveParams.Curve, curveParams.G, curveParams.N, curveParams.H, curveParams.GetSeed());
                ECPublicKeyParameters ecPublicKeyParameters = new ECPublicKeyParameters(decodePoint, domainParams);
    
                var x = ecPublicKeyParameters.Q.AffineXCoord.ToBigInteger();
                var y = ecPublicKeyParameters.Q.AffineYCoord.ToBigInteger();
    
                if (!x.Equals(new BigInteger("8706462696031173094919866327685737145866436939551712382591956952075131891462487598200779332295613073905587629438229")))
                    throw new Exception("X coord check failed");
    
                if (!y.Equals(new BigInteger("10173258529327482491525749925661342501140613951412040971418641469645769857676705559747557238888921287857458976966474")))
                    throw new Exception("Y coord check failed");
    
                Console.WriteLine("Step 1 complete");
    
                // #####
                // ##### Step 2
                // #####
                var privateKeyBytes = Convert.FromBase64String(privateKey);
                var ecPrivateKeyParameters = new ECPrivateKeyParameters("ECDHC", new BigInteger(1, privateKeyBytes), domainParams);
                var privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(ecPrivateKeyParameters);
                var ecPrivateKey = (ECPrivateKeyParameters) PrivateKeyFactory.CreateKey(privateKeyInfo);
    
                IBasicAgreement agree = AgreementUtilities.GetBasicAgreement("ECDHC");
                agree.Init(ecPrivateKey);
                BigInteger sharedKey = agree.CalculateAgreement(ecPublicKeyParameters);
                var sharedKeyBytes = sharedKey.ToByteArrayUnsigned();
                var sharedKeyBase64 = Convert.ToBase64String(sharedKeyBytes);
    
                if (sharedKeyBase64 != "2lvSJsBO2keUHRfvPG6C1RMUmGpuDbdgNrZ9YD7RYnvAcfgq/fjeYr1p0hWABeif")
                    throw new Exception("Shared key check failed");
    
                Console.WriteLine("Step 2 complete");
    
                // #####
                // ##### Step 3
                // #####
                var kdf2Bytes = Kdf2(sharedKeyBytes, decodedEphemeralPublicKey);
                var kdf2Base64 = Convert.ToBase64String(kdf2Bytes);
    
                if (kdf2Base64 != "mAzkYatDlz4SzrCyM23NhgL/+mE3eGgfUz9h1CFPhZOtXequzN3Q8w+B5GE2eU5g")
                    throw new Exception("Kdf2 failed");
    
                Console.WriteLine("Step 3 complete");
    
                // #####
                // ##### Step 4
                // #####
                var decryptionKeyBytes = kdf2Bytes.Take(32).ToArray();
                var decryptionIvBytes = kdf2Bytes.Skip(32).ToArray();
    
                var decryptionKeyBase64 = Convert.ToBase64String(decryptionKeyBytes);
                var decryptionIvBase64 = Convert.ToBase64String(decryptionIvBytes);
    
                if (decryptionKeyBase64 != "mAzkYatDlz4SzrCyM23NhgL/+mE3eGgfUz9h1CFPhZM=")
                    throw new Exception("Decryption key check failed");
    
                if (decryptionIvBase64 != "rV3qrszd0PMPgeRhNnlOYA==")
                    throw new Exception("Decryption iv check failed");
    
                var encryptedDataBytes = decodedToken.Skip(97).Take(decodedToken.Length - 113).ToArray();
                var tagBytes = decodedToken.Skip(decodedToken.Length - 16).ToArray();
    
                var encryptedDataBase64 = Convert.ToBase64String(encryptedDataBytes);
                var tagBase64 = Convert.ToBase64String(tagBytes);
    
                if (encryptedDataBase64 != "afFS7GukrGilac6DKHNTH6YFRNqjSlwSCpkXDRj+")
                    throw new Exception("Encrypted data check failed");
    
                if (tagBase64 != "pkgk9/Uq6wIyXPlMCGmOzA==")
                    throw new Exception("Tag check failed");
    
                KeyParameter keyParam = ParameterUtilities.CreateKeyParameter("AES", decryptionKeyBytes);
                ParametersWithIV parameters = new ParametersWithIV(keyParam, decryptionIvBytes);
                IBufferedCipher cipher = CipherUtilities.GetCipher("AES/GCM/NoPadding");
                cipher.Init(false, parameters);
                var resultBytes = cipher.DoFinal(encryptedDataBytes.Concat(tagBytes).ToArray());
                var resultBase64 = Convert.ToBase64String(resultBytes);
                var resultString = Strings.FromByteArray(resultBytes);
    
                if (resultString != "xXTi32iZwrQ6O8Sy6r1isKwF6Ff1Py")
                    throw new Exception("Decryption failed");
    
                Console.WriteLine("Step 4 complete");
                Console.WriteLine(resultString);
    
                Console.WriteLine();
                Console.WriteLine("Done... press any key to finish");
                Console.ReadLine();
            }
    
            static byte[] Kdf2(byte[] sharedKeyBytes, byte[] ephemeralKeyBytes)
            {
                var gen = new Kdf2BytesGenerator(new Sha256Digest());
                gen.Init(new KdfParameters(sharedKeyBytes, ephemeralKeyBytes));
    
                byte[] encryptionKeyBytes = new byte[48];
                gen.GenerateBytes(encryptionKeyBytes, 0, encryptionKeyBytes.Length);
                return encryptionKeyBytes;
            }
        }
    }
