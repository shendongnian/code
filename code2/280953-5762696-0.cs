    static readonly string Digits = "0123456789ABCDEF";
    static string ToHex(byte b)
    {
        char[] chars = new char[2];
        chars[0] = Digits[b / 16];
        chars[1] = Digits[b % 16];
        return new string(chars);
    }
