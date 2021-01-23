    public static bool IsEmpty(XElement n)
    {
        return n.IsEmpty 
            || (string.IsNullOrEmpty(n.Value) 
                && (!n.HasElements || n.Elements().All(IsEmpty)));
    }
    var doc = XDocument.Parse(original);
    var emptyNodes = doc.Descendants().Where(IsEmpty);
    foreach (var emptyNode in emptyNodes.ToArray())
    {
        emptyNode.Remove();
    }
