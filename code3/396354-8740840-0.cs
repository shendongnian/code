            void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
            {
                reader.MoveToContent();
                var outerXml = reader.ReadOuterXml();
                XElement root = XElement.Parse(outerXml);
    
                this.FieldBasic = root.Elements(XName.Get("FieldBasic", "http://foo/bar")).First().Value;
                this.FieldComplex = root.Elements(XName.Get("FieldComplex", "http://foo/bar")).First().Elements().First().Value.Trim();
            }
        
            void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
            {
                writer.WriteRaw(String.Format("\r\n\t<my:FieldBasic>\r\n\t\t{0}\r\n\t</my:FieldBasic>", this.FieldBasic));
                writer.WriteRaw(String.Format("\r\n\t<my:FieldComplex>\r\n\t\t{0}\r\n\t</my:FieldComplex>\r\n", this.FieldComplex));
            }
