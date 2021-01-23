    public IEnumerable<string> GetRankedPhrases(IEnumerable<string> phrases, string testPhrase)
    {
        return phrases
            .Select(p => new { Phrase = p, Intersection = p.Intersect(testPhrase) })
            .OrderByDescending(pi => pi.Intersection.Count())
            .Select(pi => pi.Phrase);
    }
