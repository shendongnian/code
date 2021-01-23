    using System.IO;
    using System.Xml.Serialization;
    
    namespace XmlExtensionMethods
    {
    /// <summary>
    /// Provides extension methods useful for XML Serialization and deserialization.
    /// </summary>
    public static class XMLExtensions
    {
        /// <summary>
        /// Extension method that takes objects and serialized them.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized.</typeparam>
        /// <param name="source">The object to be serialized.</param>
        /// <returns>A string that represents the serialized XML.</returns>
        public static string SerializeXML<T>(this T source) where T : class, new()
        {
            source.CheckNull("Object to be serialized.");
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, source);
                return writer.ToString();
            }
        }
    /// <summary>
        /// Extension method to string which attempts to deserialize XML with the same name as the source string.
        /// </summary>
        /// <typeparam name="T">The type which to be deserialized to.</typeparam>
        /// <param name="XML">The source string</param>
        /// <returns>The deserialized object, or null if unsuccessful.</returns>
        public static T DeserializeXML<T>(this string XML) where T : class, new()
        {
            XML.CheckNull("XML-string");
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(XML))
            {
                try { return (T)serializer.Deserialize(reader); }
                catch { return null; } // Could not be deserialized to this type.
            }
        }
    }
    
    }
    }
