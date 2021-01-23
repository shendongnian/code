    public byte[] Decrypt(byte[] buffer)
    {
        MemoryStream decryptStream = new MemoryStream();
        try
        {
            using (CryptoStream cs = new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
        }
        catch ( CryptographicException ex )
        {
            throw new InvalidKeyException(ex);
        }
        return decryptStream.ToArray();
    }
