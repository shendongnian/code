    public static string ConvertToXML<T>(T objectToConvert)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateNode(XmlNodeType.Element, objectToConvert.GetType().Name, string.Empty);
            doc.AppendChild(root);
            XmlNode childNode;
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.GetValue(objectToConvert) != null)
                {
                    childNode = doc.CreateNode(XmlNodeType.Element, prop.Name, string.Empty);
                    childNode.InnerText = prop.GetValue(objectToConvert).ToString();
                    root.AppendChild(childNode);
                }
            }            
            return doc.OuterXml;
        }
