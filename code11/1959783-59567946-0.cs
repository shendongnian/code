    public static string GetValueForAttribute(XmlNode element, string elementName, string attribute)
    {
        string value = string.Empty;
        if (element.HasChildNodes)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                value = GetValueForAttribute(node, elementName, attribute);
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
        }
        else
        {
            if (element.Name.Equals(elementName) && element.Attributes["Name"].Value.Equals(attribute))
                return element.Attributes["Value"].Value.ToString();
        }
        return value;
    }
Usage for the above method is ...
    XmlDocument doc = new XmlDocument();
    doc.Load(Path + XMLFileName);
    string value = GetValueForAttribute(doc.DocumentElement, "Parameter", "EndPoint");
**Regex**
The other way to go about reading your XML is by removing the namespaces in the elements. Following method was derived [from this site.][1]
    string filter = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
    string fileContent = File.ReadAllLines(path + XMLFileName);
    string filteredFile = Regex.Replace(fileContent, filter, "");
    XmlDocument doc2 = new XmlDocument();
    doc2.Load(Path + XMLFileName);
    string value = doc2.SelectNodes("//Application/Parameters/Parameter")
                       .Cast<XmlNode>() // Converts the Collection to List
                       .Where(x => x.Attributes["Name"].Value.Equals("EndPoint"))
                       .Select(x => x.Attributes["Value"].Value.ToString())
                       .FirstOrDefault(); // First would be value .. default would be null.
    if (!string.IsNullOrEmpty(value))
        Console.WriteLine(value);
  [1]: https://techoctave.com/c7/posts/113-c-reading-xml-with-namespace
