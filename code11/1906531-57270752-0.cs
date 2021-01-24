    string GetSubstring(string input, int index)
    {
        string returnValue = String.Empty;
        string[] substrings = input.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        returnValue = substrings.Length > index ? substrings[index] : returnValue;
        return returnValue;
    }
