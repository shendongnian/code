    var charInfo = Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue + 1)
                             .Select(Convert.ToChar)
                             .GroupBy(char.GetUnicodeCategory)
                             .ToDictionary(g => g.Key);
    foreach (var ch in charInfo[UnicodeCategory.LowercaseLetter])
    {
        Console.Write(ch);
    }
