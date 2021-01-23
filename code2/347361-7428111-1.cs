    private static IEnumerable<string> TransitiveValues(string name,
                        Dictionary<string, List<string>> lookup)
    {
        yield return name;
        List<string> children;
        if (lookup.TryGetValue(name, out children))
        {
            foreach (string child in children)
            {
                foreach (string value in TransitiveValues(child, lookup))
                {
                    yield return value;
                }
            }
        }
    }
