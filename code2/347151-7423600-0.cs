    // The key words to replace.
    var levels = new List<string> { "BLOCK", "LIST1", "LIST2", "LIST3" };
    // A counter for each level.
    var counter = new Dictionary<string, int>();
    foreach (var level in levels)
    {
        counter[level] = 0;
    }
    // The input.
    var input = "BLOCK\r\n    LIST1 Lorem ipsum dolor sit amet ...";
    // Replace each key word with incremented counter,
    // while resetting deeper levels to 0.
    var result = Regex.Replace(input, string.Join("|", levels), m =>
    {
        for (int i = levels.IndexOf(m.Value) + 1; i < levels.Count; i++)
        {
            counter[levels[i]] = 0;
        }
        return (++counter[m.Value]).ToString() + ".";
    });
