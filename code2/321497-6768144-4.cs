    static string EncodeDecode(string str)
    {
        byte[] hash = new byte[63] { 94, 37, 49, 50, 104, 68, 86, 106, 69, 68, 49, 126, 
            126, 35, 50, 57, 97, 102, 100, 109, 83, 68, 96, 54, 90, 118, 85, 89, 64, 
            104, 98, 107, 68, 66, 67, 51, 102, 110, 55, 89, 55, 101, 117, 70, 124, 82, 
            55, 57, 51, 52, 48, 57, 51, 42, 55, 97, 45, 124, 45, 32, 32, 81, 96 };
        Encoding ANSI = Encoding.GetEncoding(1252);
        byte[] input = ANSI.GetBytes(str);
        byte[] output = new byte[input.Length];
        for (int i = 0; i < input.Length; i++)
            output[i] = (byte)(input[i] ^ ~hash[(i + 1) % hash.Length]);
        return ANSI.GetString(output);
    }
