    static IEnumerable<string> Splitter(string sentences)
    {
        char sentinel = '\0';
        return sentences.Replace("Mr.", "Mr" + sentinel)
            .Replace("Mrs.", "Mrs" + sentinel)
            .Split(new[] { ". " }, StringSplitOptions.None)
            .Select(s => s.Replace("Mr" + sentinel, "Mr.")
                            .Replace("Mrs" + sentinel, "Mrs."));
    }
