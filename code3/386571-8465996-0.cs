    private int MagicConvert(int value)
    {
        string intValue = value.ToString("X");
        int result = 0;
        for (int i = 1; i <= intValue.Length; i++)
        {
            int digit;
            if (!int.TryParse(intValue.Substring(intValue.Length - i, 1), out digit))
            {
                throw new ArgumentException("Hex value contains digits in the range of 'A' to 'F'.");
            }
            result += (int)Math.Pow(10, i - 1) * digit;
        }
        return result;
    }
