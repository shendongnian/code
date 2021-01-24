    public static IEnumerable<TSource> ElementsAt<TSource>(
        this IEnumerable<TSource> source, params int[] indices)
    {
        var indicesHashSet = new HashSet<int>(indices);
        var foundElements = source.Select((Item, Index) => (Item, Index))
            .Where(p => indicesHashSet.Contains(p.Index))
            .ToDictionary(p => p.Index, p => p.Item);
        var notFoundIndices = indices.Where(i => !foundElements.ContainsKey(i)).ToList();
        if (notFoundIndices.Count > 0)
            throw new ArgumentOutOfRangeException(nameof(indices),
            $"Indices [{String.Join(", ", notFoundIndices)}] " +
            $"are outside the bounds of the {nameof(source)} sequence.");
        return indices.Select(i => foundElements[i]);
    }
