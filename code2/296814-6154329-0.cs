    public XElement XmlSerialize(object o)
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                using (StringWriter sw = new StringWriter())
                {
                    serializer.Serialize(sw, o);
                    return XElement.Parse(sw.ToString());
                }
            }
