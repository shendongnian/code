    IEnumerable<string> ToLines(this text)
    {
        // TODO: check text not null
        using (var reader = new StringReader(text))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                yield return line;
                line = reader.ReadLine();
            }
        }
    }
    IEnumerable<string> KeepEvery2ndLine(this IEnumerable<string> lines)
    {
        // TODO: check lines not null
        int lineNr = 0;
        foreach (var line in lines
        {
            ++lineNr;
            if (lineNr%2 == 0)
                yield return line;
        }
    }
    IEnumerable<string> ToWords(this string line)
    {
        // TODO: check line not null
        // when is a word a word? do you need to consider tabs? semicolons?
        // is a number like 12 a word?
    }
