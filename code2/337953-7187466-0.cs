    IEnumerable<List<T>> Permutations<T>(List<T> items)
    {
        if (items.Count == 0) yield return new List<T>();
        var copy = new List<T>(items);
        foreach (var i in items)
        {
            copy.Remove(i);
            foreach (var rest in Permutations(copy))
            {
                rest.Insert(0, i);
                yield return rest;
            }
            copy.Insert(0, i);
        }
    }
    IEnumerable<string> Anagrams(string word)
    {
        return Permutations(word.ToCharArray().ToList()).Select(x => new String(x.ToArray()));
    }
