    private static bool IsStringEndsWithDigit(string str)
    {
        string last = str.Substring(str.Length - 1, 1);
        int num;
        var isNum = int.TryParse(last, out num);
        return isNum;
    }
