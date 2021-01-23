            result = XDocument.Parse(e.Result.ToString());
            XmlNamespaceManager nsManager = new XmlNamespaceManager(new NameTable());
            XNamespace ns = result.Root.GetDefaultNamespace();
            nsManager.AddNamespace("def", ns.NamespaceName);
            IEnumerable<XElement> users = result.XPathSelectElements("/def:GetAllUserCollectionFromWeb/def:Users/def:User", nsManager);
            foreach (XElement u in users)
            {
                persons.Add(new Person()
                {
                    ID = u.Attribute("ID").Value,
                    LoginName = u.Attribute("LoginName").Value
                });
            }
