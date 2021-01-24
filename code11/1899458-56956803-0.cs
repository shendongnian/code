 c#
XmlDocument doc = new XmlDocument();
doc.Load("my.xml");
foreach(var node in doc.DocumentElement.ChildNodes)
{
    var el = node as XmlElement;
    if (el != null)
    {
        if (el.HasAttribute("xmlns"))
        {
            var ns = el.GetAttribute("xmlns");
            if (ns != null && ns != el.NamespaceURI)
            {
                el.RemoveAttribute("xmlns");
            }
        }
    }
}
doc.Save("new.xml");
Obviously you'd probably want to make it query, or issue an all-elements query, in complex scenarios.
