    private int? GetNthOccurrance(string inputString, char charToFind, int occurranceToFind)
    {
        int totalOccurrances = inputString.ToCharArray().Count(c => c == charToFind);
        if (totalOccurrances < occurranceToFind || occurranceToFind <= 0)
        {
            return null;
        }
        var charIndex =
            Enumerable.Range(0, inputString.Length - 1)
                .Select(r => new { Position = r, Char = inputString[r], Count = 1 })
                .Where(r => r.Char == charToFind);
        return charIndex
            .Select(c => new
            {
                c.Position,
                c.Char,
                Count = charIndex.Count(c2 => c2.Position <= c.Position)
            })
            .Where(r => r.Count == occurranceToFind)
            .Select(r => r.Position)
            .First();
    }
