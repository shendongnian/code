c#
public XElement RemoveAllNamespaces(XElement root)
        {
            return new XElement(
                root.Name.LocalName,
                root.HasElements ?
                    root.Elements().Select(x => RemoveAllNamespaces(x)) :
                    (object)root.Value
                );
        }
Calling Code:
c#
XElement noNsDoc = RemoveAllNamespaces(XElement.Parse(xmlString));
var xDoc = XDocument.Parse(noNsDoc.ToString());
