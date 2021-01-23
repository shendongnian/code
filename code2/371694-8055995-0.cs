    static IEnumerable<Tuple<string, HtmlNode>> GetInputNodes(HtmlDocument doc, params string[] fields)
    {
        var form = doc.DocumentNode.SelectSingleNode("//form");
        foreach (var field in fields)
        {
            var fieldNode = form.ChildNodes
                .OfType<HtmlTextNode>()
                .Where(node => node.Text.Trim().StartsWith(field, StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();
            if (fieldNode == null)
                continue;
            var input = FindCorrespondingInputNode(fieldNode);
            if (input != null)
                yield return Tuple.Create(field, input);
        }
    }
    static HtmlNode FindCorrespondingInputNode(HtmlTextNode fieldNode)
    {
        for (var currentNode = fieldNode.NextSibling;
             currentNode != null && currentNode.NodeType != HtmlNodeType.Text;
             currentNode = currentNode.NextSibling)
        {
            if (currentNode.Name == "input"
             && !currentNode.Attributes["type"].Value.Contains("hidden"))
            {
                return currentNode;
            }
        }
        return null;
    }
