    public string OutputEndOfFileCharacterSUB()
    {
         byte[] hexString = Encoding.ASCII.GetBytes('\u001A'.ToString());
         return System.BitConverter.ToString(hexString);
    }
