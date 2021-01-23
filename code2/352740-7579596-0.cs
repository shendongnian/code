    string stringFromSQL = "0x6100730064006600";
    List<byte> byteList = new List<byte>();
    string hexPart = stringFromSQL.Substring(2);
    for (int i = 0; i < hexPart.Length / 2; i++)
    {
        string hexNumber = hexPart.Substring(i * 2, 2);
        byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
    }
    byte [] original = byteList.ToArray();
