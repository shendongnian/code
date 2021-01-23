            XDocument xmlDoc = XDocument.Load("sitemap.xml");
            if (xmlDoc.Elements().Count() > 0)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    xmlDoc.Save(memStream);
                    memStream.Position = 0;
                    using (XmlReader reader = XmlReader.Create("sitemap.xml", new XmlReaderSettings() { IgnoreWhitespace = true }))
                    {
                        reader.MoveToContent();
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.LocalName.Equals("url", StringComparison.OrdinalIgnoreCase))
                            {
                                XElement el = XNode.ReadFrom(reader) as XElement;
                                if (el == null)
                                    continue;
                                XName loc = XName.Get("loc", el.Name.Namespace.NamespaceName);
                                XName changefreq = XName.Get("changefreq", el.Name.Namespace.NamespaceName);
                                XName priority = XName.Get("priority", el.Name.Namespace.NamespaceName);
                                var elLoc = el.Element(loc);
                                var elChangeFreq = el.Element(changefreq);
                                var elPriority = el.Element(priority);
                            }
                        }
                    }
                }
            }
