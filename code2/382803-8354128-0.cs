    private string TakeEverySecondChar(string input)
    {
        var result = string.Empty;
        for (int i = 0; i < input.Length; i+=2)
        {
            result += input.Substring(i, 1);
        }
        return result;
    }
