    Dictionary<string, string> replacements = data.ToDictionary(x => x.id,
                                                                x => x.value);
    foreach (XElement element in HtmlDocAsAXelement.Descendants())
    {
        string newValue;
        string id = (string) element.Attribute("id");
        if (id != null && replacements.TryGetValue(id, out newValue))
        {
            element.Value = newValue;
        }
    }
