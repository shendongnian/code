    public IEnumerable<HtmlNode> All()
    {
        var queue = new Queue<HtmlNode>(_context);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            yield return node;
            foreach (var next in node.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Element))
                queue.Enqueue(next);
        }
    }
