            if (File.Exists(path))
            {
                if (xDoc == null)
                {
                    StreamReader stream = new StreamReader(path);
                    using (stream)
                    {
                        xDoc = XDocument.Load(stream);
                    }
                }
            }
            else
            {
                xDoc = new XDocument();
                xDoc.Add(new XElement("TSD"));
            }
            xDoc.Element("TSD").Add(x);
            xmlPath = path;
            xDoc.Save(path);
