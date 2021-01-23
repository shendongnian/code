            RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
            rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), XXX));
            AsymmetricCipherKeyPair keys = rsaKeyPairGenerator.GenerateKeyPair();
            PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keys.Private);
            // Write out an RSA private key with it's asscociated information as described in PKCS8.
            byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetDerEncoded();
            // Convert to Base64 ..
            string serializedPrivateString = Convert.ToBase64String(serializedPrivateBytes);
            SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keys.Public);
            byte[] serializedPublicBytes = publicKeyInfo.ToAsn1Object().GetDerEncoded();
            string serializedPublicString = Convert.ToBase64String(serializedPublicBytes);
