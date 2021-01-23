    static IEnumerable<IList<string>> ParseLines(IEnumerable<string> lines)
    {
        var lineSet = new List<string>();
        foreach(var line in lines)
        {
            if(line.StartsWith("----"))
            {
                yield return lineSet;
                lineSet = new List<string>();
            }
            else
            {
                lineSet.Add(line);
            }
        }
    }
