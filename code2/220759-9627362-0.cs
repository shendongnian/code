    public static byte[] Bytes ( this string Key )
    {
        return Enumerable.Range(0, Key.Binary().Length / 8 )
                         .Select(Index => Convert.ToByte(
                             Key.Binary().Substring(Index * 8, 8), 2))
                         .ToArray();
    }
