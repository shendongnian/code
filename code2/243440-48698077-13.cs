    public static Guid EncodeInt24InGUID(Guid guid, uint x)
    {
        if (x >= Math.Pow(2, 24))
                throw new ArgumentOutOfRangeException("Unsigned integer is greater than 24bit");
        string strGuid = guid.ToString();
        strGuid = Utility.RemoveChars(strGuid, "-{}");//Remove any '-' and '{}' characters
        byte[] bytes = BitConverter.GetBytes(x);
        var encryptedarray = Cypher.EncryptDES(bytes, Cypher.Key);
        string EncryptedGuid = WriteBytesToString(strGuid, encryptedarray, 9);
        Guid outg;
        Guid.TryParse(EncryptedGuid, out outg);
        return outg;
    }
