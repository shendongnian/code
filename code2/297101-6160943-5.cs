    var captions = document.Descendants()
        .Select(arg =>
            new
            {
                CaptionAttribute = arg.Attribute("Caption"),
                XPath = GetXPath(arg)
            })
        .Where(arg => arg.CaptionAttribute != null)
        .Select(arg => new { Caption = arg.CaptionAttribute.Value, arg.XPath })
        .ToList();
    private static string GetXPath(XElement el)
    {
        if (el.Parent == null)
            return "/" + el.Name.LocalName;
        var name = GetXPath(el.Parent) + "/" + el.Name.LocalName;
        if (el.Parent.Elements(el.Name).Count() != 1)
            return string.Format(@"{0}[{1}]", name, (el.ElementsBeforeSelf(el.Name).Count() + 1));
        return name;
    }
