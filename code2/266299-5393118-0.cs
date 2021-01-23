    private void Do()
    {
        string str = "The {small|big} car is {red|blue}";
    
        Regex regex = new Regex("{(.*?)}", RegexOptions.Singleline);
    
        int i = 0;
        var strWithPlaceHolders = regex.Replace(str, m => "{" + (i++).ToString() + "}");
    
        var collection = regex.Matches(str);
        var alternatives = collection.OfType<Match>().Select(m => m.Value.Split(new char[] { '|', '{', '}' }, StringSplitOptions.RemoveEmptyEntries));
        var replacers = GetReplacers(alternatives);
    
        var combinations = new List<string>();
        foreach (var replacer in replacers)
        {
            combinations.Add(string.Format(strWithPlaceHolders, replacer));
        }
    }
    
    private IEnumerable<object[]> GetReplacers(IEnumerable<string[]> alternatives)
    {
        return GetAllPossibilities(0, alternatives.ToList());
    }
    
    private IEnumerable<object[]> GetAllPossibilities(int level, List<string[]> list)
    {
        if (level == list.Count - 1)
        {
            foreach (var elem in list[level])
                yield return new[] { elem };
        }
        else
        {
            foreach (var elem in list[level])
            {
                var thisElemAsArray = new object[] { elem };
                foreach (var subPossibilities in GetAllPossibilities(level + 1, list))
                    yield return thisElemAsArray.Concat(subPossibilities).ToArray();
            }
        }
        yield break;
    }
