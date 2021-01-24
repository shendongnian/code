     //Hi all I got the answer and I am posting it,hope it might help someone in future
                                 XmlNamespaceManager namespaces = new 
                                 XmlNamespaceManager(doc.NameTable);
                                 namespaces.AddNamespace("m", "our_url_link");
                     XmlNodeList nodemsg = doc.SelectNodes("//m:properties", namespaces);
                                foreach (XmlNode xnz in nodemsg)
                                {
                                customers.Add(new CustomerModel
                                {
                                //item.Element("d:No").Value
                                 No = xnz["d:No"].InnerText,
                                 Description = xnz["d:Description"].InnerText,
                                 Type = xnz["d:Type"].InnerText
                                });
                               }
