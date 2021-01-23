    // You might want to think of a better method name.
    public string ConvertUTF8ToWin1252(string source)
    {
        Encoding utf8 = new UTF8Encoding();
        Encoding win1252 = Encoding.GetEncoding(1252);
        byte[] input = source.ToUTF8ByteArray();  // Note the use of my extension method
        byte[] output = Encoding.Convert(utf8, win1252, input);
        return win1252.GetString(output);
    }
