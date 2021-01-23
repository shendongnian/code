    private void WriteDataTableToXml(DataTable dataTable, string xmlFilePath)
    {   
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineOnAttributes = true;
    
        using (StreamWriter streamWriter = new StreamWriter(xmlFilePath, false, Encoding.GetEncoding("ISO-8859-1")))
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
            {
                xmlWriter.WriteStartElement("root");
                xmlWriter.WriteStartElement("nodes");
    
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    xmlWriter.WriteStartElement("node");
    
                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        xmlWriter.WriteElementString(dataColumn.ColumnName, dataRow[dataColumn].ToString());
                    }
    
                    xmlWriter.WriteEndElement();
                }
    
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }
        }
    }
