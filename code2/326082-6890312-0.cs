    private List<string> GetStringCombinations(List<List<string>> collection)
    {
    List<string> ls = new List<string>();
    // if the collection is empty, return null to stop the recursion
    if (!collection.Any())
    {
        return null;
    }
    // recurse down the list, selecting one letter each time
    else
    {
        foreach (var letter in collection.First())
        {
            // get the collection sans the first item
            var nextCollection = collection.Skip(1).ToList();
            // construct the strings using yield return and recursion
            foreach (var tail in GetStringCombinations(nextCollection))
            {
                ls.add(letter + tail);
            }
        }
    }
    return ls;
}
