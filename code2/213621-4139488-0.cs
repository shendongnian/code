    public IEnumerable<HtmlNode> Traverse()
    {
        for (int i = 0; i < _context.Count; ++i)
        {
            yield return _context[i];
            foreach (var child in Eq(i).Children().Traverse())
                yield return child;
        }
    }
    /// <summary>
    /// Reduce the set of matched elements to the one at the specified index.
    /// </summary>
    /// <param name="index">An integer indicating the 0-based position of the element.</param>
    /// <returns></returns>
    public SharpQuery Eq(int index)
    {
        if (index < 0) index += _context.Count;
        var nodes = index >= 0 && index < _context.Count
                        ? _context.Skip(index).Take(1)
                        : Enumerable.Empty<HtmlNode>();
        return new SharpQuery(nodes, this);
    }
