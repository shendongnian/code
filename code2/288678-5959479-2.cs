    XmlDocument xDocument = new XmlDocument();
                xDocument.Load(@"YourXmlFile.xmll");
                foreach (XmlNode node in xDocument.GetElementsByTagName("publication"))
                {
                    ddlList.Items.Add(new ListItem(node.SelectSingleNode("name").InnerText,
                        node.Attributes["tcmid"].Value));
                }
                ddlList.DataValueField = "value";
                ddlList.DataTextField = "text";            
                ddlList.DataBind();
