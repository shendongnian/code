    IEnumerable<XElement> DistinctStructures(XContainer root, XName name)
    {
        return
            from d in root.Descendants(name)
            group d by GetKey(d) into g
            select g.First();
        
        string GetKey(XElement n) =>
            String.Join(",",
                n.DescendantNodes().Select(d =>
                    d is XElement e ? $"{e.Name}^{GetDepth(e)}"
                    : d is XText t ? $"<text>^{GetDepth(t)}"
                    : default
                )
            );
        int GetDepth(XObject o)
        {
            var depth = 0;
            for (var c = o; c != null; c = c.Parent)
                ++depth;
            return depth;
        }
    }
