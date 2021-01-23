    public static string ConvertToString(long value, string digits, int digitCount)
    {
        char[] chars = new char[digitCount];
        for (int i = digitCount - 1 ; i >= 0; i--)
        {
            chars[i] = digits[(int)(value % digits.Length)];
            value = value / digits.Length;
        }
        return new string(chars);
    }
