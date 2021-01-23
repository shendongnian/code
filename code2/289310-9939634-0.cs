            using (MemoryStream memS = new MemoryStream())
            {
                //set up the xml settings
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = OmitXmlHeader;
                using (XmlWriter writer = XmlTextWriter.Create(memS, settings))
                {
                    //write the XML to a stream
                    xmlSerializer.Serialize(writer, objectToSerialize);
                    writer.Close();
                }
                //encode the memory stream to xml
                retString.AppendFormat("{0}", encoding.GetString(memS.ToArray()));
                memS.Close();
            }
