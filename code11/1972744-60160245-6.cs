    public static string ConvertObjectToXML<T>(T ModelClass)
            {
                XmlSerializer xsObject = new XmlSerializer(typeof(T));
                var inputObject = ModelClass;
                var xmlString = "";
    
                using (var sw = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sw))
                    {
                        xsObject.Serialize(writer, inputObject);
                        xmlString = sw.ToString();
                    }
                }
    
                return xmlString;
            }
