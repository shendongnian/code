    var root = doc.DocumentNode;
    var sb = new StringBuilder();
    foreach (var node in root.DescendantNodesAndSelf())
    {
        if (!node.HasChildNodes)
        {
            string text = node.InnerText;
            if (!string.IsNullOrEmpty(text))
                sb.AppendLine(text.Trim());
        }
    }
