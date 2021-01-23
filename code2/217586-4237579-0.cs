        internal string Convert()
        {
            string[] lines = {
                                 "Company Name 1, 123 Main St.",
                                 "Company Name 2, 1 Elm St.",
                                 "Company Name 2, 2 Elm St"
                             };
            //var lines = File.ReadLines(path);
            var builder = new StringBuilder();
            foreach (var line in lines)
            {
                var fields = line.Split(',');
               
                var settings = new XmlWriterSettings {OmitXmlDeclaration = true};
                using (var writer = XmlWriter.Create(builder, settings))
                {
                   
                    //writer.WriteStartDocument();
                    writer.WriteStartElement("ArrayofBusiness");
                    writer.WriteStartElement("Business");
                    writer.WriteElementString("Name", fields[0]);
                    writer.WriteStartElement("AddressList");
                    writer.WriteStartElement("Address");
                    writer.WriteElementString("AddressLine", fields[1]);
                    
                    writer.WriteEndElement();//Address
                    writer.WriteEndElement();//AddressList
                    writer.WriteEndElement();//Business
                    writer.WriteEndElement();//ArrayOfBusiness
                    //writer.WriteEndDocument();
                }
            }
            return builder.ToString();
        }
