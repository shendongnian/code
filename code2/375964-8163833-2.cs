    public string EncryptNum(string numbers, string encryptString)
    {
        string result = string.Empty;
        for (int i = 0; i < numbers.Length; i++)
        {
            result += encryptString.Substring(Math.Min(int.Parse(numbers.Substring(i, 1)), encryptString.Length) - 1, 1);
        }
        return result;
    }
