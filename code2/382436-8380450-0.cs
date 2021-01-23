    var xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(list.DefaultView.GetViewXml());
    // etc
    XsltListViewWebPart wp = new XsltListViewWebPart();
    wp.XmlDefinition = xmlDocument.OuterXml;
    // etc
    wp.DataBind();
    
                using (var stringWriter = new StringWriter())
                {
                    using (var writer = new HtmlTextWriter(stringWriter))
                    {
                        wp.RenderControl(writer);
                    }
    
                    return stringWriter.ToString();
                }
