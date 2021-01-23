    public byte[] Encrypt(Byte[] bytes) //Change To take in a byte[]
    {
        //Translates our text value into a byte array.
        //Byte[] bytes = UTFEncoder.GetBytes(TextValue); <-- REMOVE THIS LINE
    
        ... do stuff with `bytes`
    }
    public byte[] Decrypt(byte[] EncryptedValue) //now returns a byte array instead of a string
    {
        //return UTFEncoder.GetString(decryptedBytes); <-- JUST RETURN THE BYTE[] INSTEAD
        return decryptedBytes;
    }
