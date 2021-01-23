            /// saving it :
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.IO.File.WriteAllText(filename, doc.Value);
            /// loading it back in :
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.LoadXml(System.IO.File.ReadAllText(filename));
