    private static void SortRichTextBox(RichTextBox richTextBox)
    {
        var lineArray = richTextBox.Lines;
        Array.Sort(lineArray, delegate(string a, string b)
        {
            // I omitted Important corner cases like malformed lines,
            // empty strings, and nulls.
            // Additional sort cases can be added to the array as needed.
            var sortOrder = new[] { "1111", "2222", "4444", "9999", "DDDD" };
            var aTokens = a.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var bTokens = b.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var aSignifier = Array.FindIndex(sortOrder, item => aTokens[5].Contains(item));
            var bSignifier = Array.FindIndex(sortOrder, item => bTokens[5].Contains(item));
            // This is where your first rule is being implemented, based on the data
            // from the last column.  The math is unimportant, what matters is the 
            // return being positive vs. negative vs. zero.
            if (aSignifier != bSignifier)
                return aSignifier - bSignifier;
            // This is where your second rule is being implemented, as a backup when
            // the result from the first rule indicates equality.  We're just falling
            // through to ordinary string comparison on the second column.
            return aTokens[1].CompareTo(bTokens[1]);
        });
        // We want to call the setter to get the textbox to update.
        richTextBox.Lines = lineArray;
    }
