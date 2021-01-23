    public static void RemoveWithNextWhitespace(this XElement element)
    {
        element.NodesAfterSelf()
               .TakeWhile(node => !(node is XElement))
               .Where(node => node is XText)
               .ToList().ForEach(node => node.Remove());
        element.Remove();
    }
