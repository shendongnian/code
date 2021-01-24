    IEnumerable<XElement> DistinctStructures(XContainer root, XName name)
    {
        return
            from n in root.Descendants(name)
            group n by GetKey(n) into g
            select g.First();
        
        string GetKey(XElement node) =>
            String.Join(",",
                node.DescendantNodes().Select(n =>
                    n is XElement e ? $"{e.Name}^{GetDepth(e)}"
                    : n is XText t ? $"<text>^{GetDepth(t)}"
                    : default
                )
            );
        int GetDepth(XObject e)
        {
            var depth = 0;
            for (var c = e; c != null; c = c.Parent)
                ++depth;
            return depth;
        }
    }
