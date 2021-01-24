    var findList = new List<string>() { "boy", "car", "ball" };
    var replaceList = new List<string>() { "dog", "bar", "bone" };
    // Create a dictionary from the lists or have a dictionary from the beginning.
    var dictKeywords = findList.Select((s, i) => new { s, i })
                               .ToDictionary(x => x.s, x => replaceList[x.i]);
    string input = "the boy sold his car to buy a ball";
    // Construct the regex pattern by joining the dictionary keys with an 'OR' operator.
    string pattern = string.Join("|", dictKeywords.Keys.Select(s => Regex.Escape(s)));
    string output =
        Regex.Replace(input, pattern, delegate (Match m)
        {
            string replacement;
            if (dictKeywords.TryGetValue(m.Value, out replacement)) return replacement;
            return m.Value;
        });
    Console.WriteLine(output);
