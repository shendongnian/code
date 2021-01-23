            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof (YourType));
                serializer.Serialize(writer, yourObject);
            }
