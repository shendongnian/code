    static JToken FilterByJSONPath(JToken document, string jsonPath)
    {
        var matches = jPaths.SelectMany(path => document.SelectTokens(path, false));
        return MergeAncestry(matches);
    }
    static JToken MergeAncestry(IEnumerable<JToken> tokens)
    {
        if (tokens == null || !tokens.Any())
        {
            return new JObject();
        }
        // Get a dictionary of tokens indexed by their depth
        var tokensByDepth = tokens
            .GroupBy(t => t.Ancestors().Count())
            .ToDictionary(
                g => g.Key, 
                g => g.Select(node => new CarbonCopyToken { Original = node, CarbonCopy = node.DeepClone() })
                        .ToList());
        // start at the deepest level working up
        int depth = tokensByDepth.Keys.Max();
        for (int i = depth; i > 0; i--)
        {
            // If there's nothing at the next level up, create a list to hold parents of children at this level
            if (!tokensByDepth.ContainsKey(i - 1))
            {
                tokensByDepth.Add(i - 1, new List<CarbonCopyToken>());
            }
            // Merge all tokens at this level into families by common parent
            foreach (var parent in MergeCommonParents(tokensByDepth[i]))
            {
                tokensByDepth[i - 1].Add(parent);
            }
        }
        // we should be left with a list containing a single CarbonCopyToken - contining the root of our copied document and the root of the source
        var cc = tokensByDepth[0].FirstOrDefault();
        return cc?.CarbonCopy ?? new JObject();
    }
    static IEnumerable<CarbonCopyToken> MergeCommonParents(IEnumerable<CarbonCopyToken> tokens)
    {
        var newParents = tokens.GroupBy(t => t.Original.Parent).Select(g => new CarbonCopyToken {
            Original = g.First().Original.Parent,
            CarbonCopy = CopyCommonParent(g.First().Original.Parent, g.AsEnumerable())
            });
        return newParents;
    }
    static JToken CopyCommonParent(JToken parent, IEnumerable<CarbonCopyToken> children)
    {
        switch (parent)
        {
            case JProperty _:
                return new JProperty(((JProperty)parent).Name, children.First().CarbonCopy);
            case JArray _:
                var newParentArray = new JArray();
                foreach (var child in children)
                {
                    newParentArray.Add(child.CarbonCopy);
                }
                return newParentArray;
            default: // JObject, or any other type we don't recognise
                var newParentObject = new JObject();
                foreach (var child in children)
                {
                    newParentObject.Add(child.CarbonCopy);
                }
                return newParentObject;
        }
    }
