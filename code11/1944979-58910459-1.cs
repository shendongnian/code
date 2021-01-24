      XDocument xmldoc = XDocument.Load("myxml.xml");
            var @namespace = xmldoc.Root.GetDefaultNamespace();// Or var @namespace = "http://localhost:8099/"
            var employee = xmldoc.Descendants(@namespace + "Table").Select(x => new
            {
                ID = x.Element(@namespace + "ID"),
                Name = x.Element(@namespace + "Name"),
                Age = x.Element(@namespace + "Age"),
            }).FirstOrDefault();
