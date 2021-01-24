    public static class XElementExtension
    {
        public static bool HasElement(this XElement xElement, string elementName)
        {
            return xElement.Elements(elementName).Any();
        }        
    }
    
    // Main
    var xmlDocument = XElement.Load(@"TestFile.xml", LoadOptions.None); 
    string elementName = "DirectoryPath";
    bool hasElement = xmlDocument.HasElement(elementName);
    if(hasElement)
    {
        Console.WriteLine(xmlDocument.Elements(elementName).First().Value);
    }
