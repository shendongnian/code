    public static string ConvertToString(int value, string digits, int digitCount)
    {
        char[] chars = new char[digitCount];
        for (int i = digitCount -1 ; i >= 0; i++)
        {
            chars[i] = digits[value % digits.Length];
            value = value / digits.Length;
        }
        return new string(chars);
    }
