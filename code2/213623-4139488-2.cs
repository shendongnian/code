    public IEnumerable<HtmlNode> Traverse()
    {
        var stack = new Stack<HtmlNode>(_context);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            yield return node;
            foreach (var next in node.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Element))
                stack.Push(next);
        }
    }
