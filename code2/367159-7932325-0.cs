    public string Serialise(T someObject)
            {
                XmlSerializer ser = new XmlSerializer(typeof (T));
                MemoryStream memStream = new MemoryStream();
                XmlConfigTextWriter xmlWriter = new XmlConfigTextWriter(memStream, Encoding.UTF8);
                xmlWriter.Namespaces = true;
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", ""); //we don't want namespace data here.                
                ser.Serialize(xmlWriter, someObject, ns);
                xmlWriter.Close();
                memStream.Close();
                string xml = Encoding.UTF8.GetString(memStream.GetBuffer());
                xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
                xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
                return xml;
            }
