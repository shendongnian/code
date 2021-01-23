    void WriteXml(string xmlFileName, DataRowCollection rows)
    {
        var xmlSettings = new XmlWriterSettings { Indent = true };
        using(StreamWriter stream = new StreamWriter(xmlFileName))
        using(XmlWriter writer = XmlWriter.Create(stream, settings))
        {
            writer.WriteStartElement("products");
            foreach(DataRow row in rows)
            {
                writer.WriteStartElement("product");
                writer.WriteElementString("ProductID", row["ProductID"].ToString());
                writer.Flush();
                stream.WriteLine(); //insert new line
                writer.WriteElementString("Product", row["Product"].ToString());
                writer.Flush();
                stream.WriteLine(); //insert new line
                //repeat for rest of columns/elements
                //...
                
                writer.WriteEndElement(); //end product
            }
            writer.WriteEndElement(); //end products
        }
    }
