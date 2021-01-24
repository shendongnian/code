        public string GetXmlForModels(IEnumerable<DataModel> dataModels)
        {
            //Assume a list of DataModels is in dataModels of type IEnumerable<DataModel>
            var doc = new XmlDocument();
            foreach (var model in dataModels)
            {
                var row = (XmlElement)doc.AppendChild(doc.CreateElement("row"));
                row.SetAttribute("xmlns:od", "urn:schemas-microsoft-com:officedat");
                row.SetAttribute("generated", DateTime.Now.ToString("yy-MM-ddTHH:mm:ss"));
                var sifraElement = doc.CreateElement("Sifra");
                sifraElement.InnerText = model.Sifra;
                row.AppendChild(sifraElement);
                
                //Repeat top 3 lines for each element ...
                doc.AppendChild(row);
            }
            return doc.OuterXml;
        }
