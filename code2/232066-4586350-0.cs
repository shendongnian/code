    private static readonly Encoding Iso88591 = Encoding.GetEncoding("ISO8859-1");
    public static void Main() {
        var bytes = new Byte[] { 65 };
        var chars = Iso88591.GetChars(bytes);
    }
