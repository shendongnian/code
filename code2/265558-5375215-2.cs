    public static HtmlNode RemoveChild(HtmlNode parent, HtmlNode oldChild, bool keepGrandChildren)
    {
        if (oldChild == null)
            throw new ArgumentNullException("oldChild");
        if (oldChild.HasChildNodes && keepGrandChildren)
        {
            HtmlNode prev = oldChild.PreviousSibling;
            List<HtmlNode> nodes = new List<HtmlNode>(oldChild.ChildNodes.Cast<HtmlNode>());
            nodes.Sort(new StreamPositionComparer());
            foreach (HtmlNode grandchild in nodes)
            {
                parent.InsertAfter(grandchild, prev);
            }
        }
        parent.RemoveChild(oldChild);
        return oldChild;
    }
    // this helper class allows to sort nodes using their position in the file.
    private class StreamPositionComparer : IComparer<HtmlNode>
    {
        int IComparer<HtmlNode>.Compare(HtmlNode x, HtmlNode y)
        {
            return y.StreamPosition.CompareTo(x.StreamPosition);
        }
    }
