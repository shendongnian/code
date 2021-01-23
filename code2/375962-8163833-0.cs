    public string ConvertNumToAlpha(string numbers)
    {
        string result = string.Empty;
        for (int i = 0; i < numbers.Length; i++)
        {
            result += Convert.ToChar(int.Parse(numbers.Substring(i, 1)) + 64);
        }
        return result;
    }
