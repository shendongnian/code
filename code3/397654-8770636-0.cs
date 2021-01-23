        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(@"<html>" + 
            "<a href='#compantnameURL1#'>#companyname1#</a>" +
            "<a href='#compantnameURL2#'>#companyname2#</a>" +
            "</html>");
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = ("    ");
        settings.Encoding = Encoding.UTF8;
        
        using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
        {                                
            writer.WriteStartDocument();
            writer.WriteStartElement("xsl", "stylesheet", "http://www.w3.org/1999/XSL/Transform");
            writer.WriteStartElement("template", "http://www.w3.org/1999/XSL/Transform");
            writer.WriteAttributeString("match", "/");
            writer.WriteElementString("apply-templates", "http://www.w3.org/1999/XSL/Transform", "");
            writer.WriteEndElement();
            writer.WriteStartElement("template", "http://www.w3.org/1999/XSL/Transform");
            writer.WriteAttributeString("match", "test/");
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a"))
            {
                HtmlAttribute att = link.Attributes["href"];
                writer.WriteStartElement("a");
                    writer.WriteStartElement("attribute", "http://www.w3.org/1999/XSL/Transform");
                        writer.WriteStartElement("value-of", "http://www.w3.org/1999/XSL/Transform");
                            writer.WriteAttributeString("select", att.Value);
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteStartElement("value-of", "http://www.w3.org/1999/XSL/Transform");
                        writer.WriteAttributeString("select", link.InnerText);
                    writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
          
        }
