            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writeXML = XmlWriter.Create("test.xml", settings);
            writeXML.WriteStartDocument();
            writeXML.WriteComment(@" This file was made by @author");
            writeXML.WriteStartElement("videos");
            foreach (var item in myList)
            {
                writeXML.WriteStartElement("video");
                writeXML.WriteAttributeString("ID", item.Key.ToString());
                writeXML.WriteAttributeString("Name", item.Value);
                    writeXML.WriteStartElement("object");
                    writeXML.WriteAttributeString("A", item.Key.ToString());
                    writeXML.WriteAttributeString("B", item.Value);
                    writeXML.WriteEndElement();
                writeXML.WriteEndElement();
            }
            writeXML.WriteEndElement();
            writeXML.WriteEndDocument();
            writeXML.Close();
