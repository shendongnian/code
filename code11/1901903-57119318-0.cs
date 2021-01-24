    private static IEnumerable<string> GetItems(string text)
    {
        var items = new List<string>();
        var openBraceIndexes = text.Select((chr, index) => new { chr = chr, index })
            .Where(item => item.chr == '{').ToList();
        var closeBraceIndexes = text.Select((chr, index) => new { chr, index })
            .Where(item => item.chr == '}').ToList();
        if (openBraceIndexes.Count != closeBraceIndexes.Count)
        {
            throw new FormatException("text contains an unequal number of open and close braces");
        }
        for (int i = 0; i < openBraceIndexes.Count; i++)
        {
            var startIndex = openBraceIndexes[i].index + 1;
            var length = closeBraceIndexes[i].index - startIndex;
            items.Add(text.Substring(startIndex, length).Trim());
        }
        return items;
    }
