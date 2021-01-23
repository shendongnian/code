    private static void SortRichTextBox(RichTextBox richTextBox)
    {
        var lineArray = richTextBox.Lines;
        Array.Sort(lineArray, delegate(string a, string b)
        {
            //... omitted corner cases like malformed lines, empty strings, and nulls ...
            var aTokens = a.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var bTokens = b.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var aSignifier = GetSignifier(aTokens[5]);
            var bSignifier = GetSignifier(bTokens[5]);
            if (bSignifier != aSignifier)
                return aSignifier - bSignifier;
            return aTokens[1].CompareTo(bTokens[1]);
        });
        richTextBox.Lines = lineArray;
    }
    private static int GetSignifier(string token)
    {
        if (token.Contains("1111"))
            return 1;
        if (token.Contains("2222"))
            return 2;
        if (token.Contains("4444"))
            return 3;
        if (token.Contains("9999"))
            return 4;
        if (token.Contains("DDDD"))
            return 5;
        return 0;
    }
