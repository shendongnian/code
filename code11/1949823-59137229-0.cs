                XmlDocument doc2 = new XmlDocument();
                XNamespace ns = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
                 XElement paymentMethodEl =  new XElement("PaymentMethod",
                      new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                      new XAttribute(ns + "type", "CreditTransferType"));
                doc2.LoadXml(paymentMethodEl.ToString());
                XmlWriter writer2 = XmlWriter.Create(Path.Combine(Settings.Default.InvoiceXmlFolder, "doc2.xml"), settings);
                doc2.Save(writer2);
                XmlNode paymentMethod = doc.ImportNode(doc2.FirstChild, true);
                rootNode.AppendChild(paymentMethod);
