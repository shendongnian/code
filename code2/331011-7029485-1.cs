    public static byte[] Symmetric(bool encrypt, byte[] plaintext, string ikey)
    {
        if (plaintext.Length == 0) return plaintext;
        // setting up the services can be very expensive, so I'll cache them
        // into a static dictionary.
        SymmetricSetup setup;
        if (!_dictSymmetricSetup.TryGetValue(ikey, out setup))
        {
            setup = new SymmetricSetup();
            setup.des = new DESCryptoServiceProvider { Mode = CipherMode.CBC, 
                Padding = PaddingMode.Zeros };
            setup.hash = Hash(Encoding.ASCII.GetBytes(ikey));
            setup.key = setup.hash.ForceLength(8, 0);
            setup.IV = Encoding.ASCII.GetBytes("init vec");
            setup.des.Key = setup.key;
            setup.des.IV = setup.IV;
            setup.encrypt = setup.des.CreateEncryptor(setup.des.Key, setup.des.IV);
            setup.decrypt = setup.des.CreateDecryptor(setup.des.Key, setup.des.IV);
            _dictSymmetricSetup[ikey] = setup;
        }
        var transform = encrypt ? setup.encrypt : setup.decrypt;
        var memStreamEncryptedData = new MemoryStream();
        var encStream = new CryptoStream(memStreamEncryptedData, transform, CryptoStreamMode.Write);
            
        if (encrypt)
            encStream.Write(new[] {(byte) ((8 - (plaintext.Length + 1)%8)%8)}, 0, 1);
        encStream.Write(plaintext, 0, plaintext.Length);
        encStream.FlushFinalBlock();
        encStream.Close();
        memStreamEncryptedData.Flush();
        var ciphertext = memStreamEncryptedData.ToArray();
        byte b;
        if (!encrypt)
            if (byte.TryParse("" + ciphertext[0], out b))
                ciphertext = ciphertext.Skip(1).Take(ciphertext.Length - b - 1).ToArray();
        return ciphertext;
    }
