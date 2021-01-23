    XmlDocument doc = new XmlDocument();
    doc.Load(spath);
    XmlNode snippet = doc.CreateNode(XmlNodeType.Element, "Snippet", null);
                
    XmlAttribute att = doc.CreateAttribute("name");
    att.Value = name.Text;
    snippet.Attributes.Append(att);
    
    XmlNode snippetCode = doc.CreateNode(XmlNodeType.Element, "SnippetCode", null);
    snippetCode.InnerText = code.Text;
    
    snippet.AppendChild(snippetCode);
    
    doc.SelectSingleNode("//Snippets").AppendChild(snippet);
