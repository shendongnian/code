    public static void RemoveWithNextWhitespace(this XElement element)
    {
        if (element.PreviousNode is XText textNode)
        {
            textNode.Remove();
        }
        
        element
        .Remove();
    }
