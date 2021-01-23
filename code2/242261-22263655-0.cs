    /// <summary>
    /// A generic serializer\deserializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Serializer<T>
    {
        /// <summary>
        /// serialize an instance to xml
        /// </summary>
        /// <param name="instance"> instance to serialize </param>
        /// <returns> instance as xml string </returns>
        public static string Serialize(T instance)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                XmlSerializer serializer = new XmlSerializer(instance.GetType());
                serializer.Serialize(writer, instance);
            }
            return sb.ToString();
        }
    
        /// <summary>
        /// deserialize an xml into an instance
        /// </summary>
        /// <param name="xml"> xml string </param>
        /// <returns> instance </returns>
        public static T Deserialize(string xml)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                foreach (Type t in types)
                {
                    XmlSerializer serializer = new XmlSerializer(t);
                    if (serializer.CanDeserialize(reader))
                        return (T)serializer.Deserialize(reader);
                }
            }
 
            return default(T);
        }
    
        /// <summary>
        /// store all derived types of T:
        /// is used in deserialization
        /// </summary>
        private static Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                                            .SelectMany(s => s.GetTypes())
                                            .Where(t => typeof(T).IsAssignableFrom(t)
                                                && t.IsClass
                                                && !t.IsGenericType)
                                                .ToArray();
    }
