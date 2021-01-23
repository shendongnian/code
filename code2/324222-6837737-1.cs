    private static void SortRichTextBox(RichTextBox richTextBox)
    {
        var lineArray = richTextBox.Lines;
        Array.Sort(lineArray, delegate(string a, string b)
        {
            // I omitted Important corner cases like malformed lines,
            // empty strings, and nulls.
            var aTokens = a.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var bTokens = b.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var aSignifier = GetSignifier(aTokens[5]);
            var bSignifier = GetSignifier(bTokens[5]);
            // This is where your first rule is being implemented, based on the data
            // from the last column.  The math is unimportant, what matters is the 
            // return being positive vs. negative vs. zero.
            if (bSignifier != aSignifier)
                return aSignifier - bSignifier;
            // This is where your second rule is being implemented, as a backup when
            // the result from the first rule indicates equality.  We're just falling
            // through to ordinary string comparison on the second column.
            return aTokens[1].CompareTo(bTokens[1]);
        });
        // We want to call the setter to get the textbox to update.
        richTextBox.Lines = lineArray;
    }
    private static int GetSignifier(string token)
    {
        // The numbers don't matter here, as long as the indicate the 
        // right ascending order.
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
