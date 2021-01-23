    public static void RemoveWithNextWhitespace(this XElement element)
    {
        IEnumerable<XNode> textNodes
            = element.NodesAfterSelf().TakeWhile(node => node is XText);
        if (element.ElementsAfterSelf().Any()) {
            // Easy case, remove following text nodes.
            textNodes.ToList().ForEach(node => node.Remove());
        } else {
            // Remove trailing whitespace.
            textNodes.Cast<XText>().TakeWhile(text => !text.Value.Contains("\n"))
                     .ToList().ForEach(text => text.Remove());
            // Fetch text node containing newline, if any.
            XText newLineTextNode
                = element.NodesAfterSelf().OfType<XText>().FirstOrDefault();
            if (newLineTextNode != null) {
                string value = newLineTextNode.Value;
                if (value.Length > 1) {
                    // Composite text node, trim until newline (inclusive).
                    newLineTextNode.AddAfterSelf(
                        new XText(value.SubString(value.IndexOf('\n') + 1)));
                }
                // Remove original node.
                newLineTextNode.Remove();
            }
        }
        element.Remove();
    }
