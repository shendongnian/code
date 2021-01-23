    public static string Str2Hex(string strMessage)
    {
        byte[] ba = Encoding.BigEndianUnicode.GetBytes(strMessage);
        string strHex = BitConverter.ToString(ba);
        strHex = strHex.Replace("-", "");
        return strHex;
     }
