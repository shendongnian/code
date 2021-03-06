        public static string SerializeAsXml<TSource>(object element) where TSource : new()
        {
            return SerializeAsXml<TSource>(element, new Type[] {});
        }
        public static string SerializeAsXml<TSource>(object element, Type[] extraTypes) where TSource : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TSource), extraTypes);
            StringBuilder output = new StringBuilder();
            using (StringWriter writer = new XmlStringWriter(output))
            {
                serializer.Serialize(writer, element);
            }
            return output.ToString();
        }
        public static TDestination Deserialize<TDestination>(string xmlPath) where TDestination : new()
        {
            return Deserialize<TDestination>(xmlPath, new Type[] { });
        }
        public static TDestination Deserialize<TDestination>(string xmlPath, Type[] extraTypes) where TDestination : new()
        {
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fs);
                XmlSerializer serializer = new XmlSerializer(typeof(TDestination), extraTypes);
                if (serializer.CanDeserialize(reader))
                {
                    return (TDestination)serializer.Deserialize(reader);
                }
            }
            return default(TDestination);
        }
