    private static bool IsStringEndsWithDigit(string str)
    {
        if (String.IsNullOrEmpty(str))
        {
            return false;
            // or throw an exception
            // throw new Exception("string can not be empty");
        }
        string last = str.Substring(str.Length - 1, 1);
        int num;
        var isNum = int.TryParse(last, out num);
        return isNum;
    }
