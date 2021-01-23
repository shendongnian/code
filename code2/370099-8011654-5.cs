    private static void DeriveKeyAndIV(byte[] data, byte[] salt, int count, out byte[] key, out byte[] iv)
    {
        List<byte> hashList = new List<byte>();
        byte[] currentHash = new byte[0];
        int preHashLength = data.Length + ((salt != null) ? salt.Length : 0);
        byte[] preHash = new byte[preHashLength];
        System.Buffer.BlockCopy(data, 0, preHash, 0, data.Length);
        if (salt != null)
            System.Buffer.BlockCopy(salt, 0, preHash, data.Length, salt.Length);
        MD5 hash = MD5.Create();
        currentHash = hash.ComputeHash(preHash);          
        
        for (int i = 1; i < count; i++)
        {
            currentHash = hash.ComputeHash(currentHash);            
        }
        
        hashList.AddRange(currentHash);
        while (hashList.Count < 48) // for 32-byte key and 16-byte iv
        {
            preHashLength = currentHash.Length + data.Length + ((salt != null) ? salt.Length : 0);
            preHash = new byte[preHashLength];
            System.Buffer.BlockCopy(currentHash, 0, preHash, 0, currentHash.Length);
            System.Buffer.BlockCopy(data, 0, preHash, currentHash.Length, data.Length);
            if (salt != null)
                System.Buffer.BlockCopy(salt, 0, preHash, currentHash.Length + data.Length, salt.Length);
            currentHash = hash.ComputeHash(preHash);            
            for (int i = 1; i < count; i++)
            {
                currentHash = hash.ComputeHash(currentHash);
            }
            hashList.AddRange(currentHash);
        }
        hash.Clear();
        key = new byte[32];
        iv = new byte[16];
        hashList.CopyTo(0, key, 0, 32);
        hashList.CopyTo(32, iv, 0, 16);
    }
