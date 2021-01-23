    static void test()
        {
            var buf = new byte[255];
            for (byte i = 0; i < buf.Length; i++)
                buf[i] = i;
            //encrypting
            var uniqueSalt = new byte[16]; //** WARNING **: MUST be unique for each stream otherwise there is NO security
            var baseStream = new MemoryStream();
            var cryptor = new SeekableAesStream(baseStream, "password", uniqueSalt);
            cryptor.Write(buf, 0, buf.Length);
            //decrypting at position 200
            cryptor.Position = 200;
            var decryptedBuffer = new byte[50];
            cryptor.Read(decryptedBuffer, 0, 50);
        }
