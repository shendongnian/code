        public static XElement ToXElement<T>(this object value)
        {
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    memoryStream = null;
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, value);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }
