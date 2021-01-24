    var irrelevantWords = new List<string>
    {
        "and", "is", "the", "of"
    };
    string original = "yeet is and this because working is  what help me.";
    List<string> result = new List<string>();
    foreach (string word in original.Split(" "))
    {
        if (irrelevantWords.IndexOf(word) >= 0)
        {
            result.Add(word);
        }
    }
    return string.Join(" ", result);
