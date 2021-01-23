     public static string Transform(string xml, string xsl, XsltArgumentList argsList)
            {
                XDocument selectedXml = XDocument.Parse(xml);
                XslCompiledTransform xmlTransform = new XslCompiledTransform();
    
                StringBuilder htmlOutput = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(htmlOutput);
    
                xmlTransform.Load(new XmlTextReader(new StringReader(xsl)));
                xmlTransform.Transform(selectedXml.CreateReader(), argsList, writer);
    
                return htmlOutput.ToString();
            }
