    XElement x = GenerateTelemetryNode(h); //Create a new element to append
            if (File.Exists(path))
            {
                if (xDoc == null)
                {
                    StreamReader reader = new StreamReader(path);
                    xDoc = XDocument.Load(reader);
                    reader.Close();
                    reader.Dispose();
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
