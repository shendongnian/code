    using System.Data;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    public void xmltest(string xmlFilePath, string xslFilePath, string outFilePath) 
    {
        var doc = new XPathDocument(xmlFilePath);
        var writer = XmlWriter.Create(outFilePath);
        var transform = new XslCompiledTransform();
        
        // The following two lines are only needed if you need scripting.
        // Because of security considerations read up on that topic on MSDN first.
        var settings = new XsltSettings();
        settings.EnableScript = true;
    
        transform.Load(xslFilePath,settings,null);
        
        transform.Transform(doc, writer);
    
    }
