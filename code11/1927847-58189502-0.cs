        /// <summary>
        /// Serializes the object to xml string.
        /// </summary>
        /// <returns>xml serialization.</returns>
        public static string SerializeToXml<T>(this T instance)
            where T : class, new()
        {
            string result;
            var format = new XmlSerializer(typeof(T));
            using (var strmr = new StringWriter())
            {
                format.Serialize(strmr, instance);
                result = strmr.ToString();
            }
            return result;
        }
        /// <summary>
        /// Deserializes xml serialized objects.
        /// </summary>
        /// <param name="xmlDocument">serialized string.</param>
        /// <param name="result">out parameter.</param>
        /// <returns>Instance object.</returns>
        public static bool TryParseXml<T>(this string xmlDocument, out T result)
            where T : class, new()
        {
            result = null;
            if (string.IsNullOrWhiteSpace(xmlDocument))
            {
                return false;
            }
            try
            {
                using (TextReader str = new StringReader(xmlDocument))
                {
                    var format = new XmlSerializer(typeof(T));
                    XmlReader xmlReader = XmlReader.Create(str);
                    if (format.CanDeserialize(xmlReader))
                    {
                        result = format.Deserialize(xmlReader) as T;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return !(result is null);
        }
