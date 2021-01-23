    public string GetImmediateInnerText(XmlNode node)
    {
        StringBuilder builder = new StringBuilder();
        foreach (XmlNode child in node.SelectNodes("text()")) {
            builder.Append(child.Value);
        }
        return builder.ToString();
    }
