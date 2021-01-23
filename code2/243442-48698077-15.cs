    public static uint DecodeInt24FromGUID(Guid guid)
    {
        string strGuid = guid.ToString();
        strGuid = Utility.RemoveChars(strGuid, "-{}");
        byte[] EncryptedBytes = GetBytesFromString(strGuid, 9,8);
        var decrypted = Cypher.DecryptDES(EncryptedBytes, Cypher.Key);
        uint DecryptedUint = BitConverter.ToUInt32(decrypted, 0);
        return DecryptedUint;
    }
