    static string ReplaceByIndex(string text, char newValue, params int[] indexes)
    {
        var array = text.ToCharArray();
        foreach (var index in indexes)
        {
            array[index] = newValue;
        }
        return new string(array);
    }
