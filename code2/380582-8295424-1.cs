     public static object Deserialize(string xml)
     {
            var deserializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                return (MyClass)deserializer.Deserialize(reader);
            }
     }
