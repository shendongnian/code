    public IEnumerable<string> GetLines(string input)
    {
        foreach (var line in input.Split(new [] {'|' }, StringSplitOptions.RemoveEmptyEntries))
        {
            if (Char.IsDigit(line[0]) && Char.IsDigit(line[line.Length - 1]))
                yield return "|" + line + "|";
            yield return line;
        }
    }
