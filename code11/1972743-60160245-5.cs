    public static T ConvertXmlToObject<T>(String xml)
        {
            T result = default(T);
            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        result =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // Throw message for invalid XML
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
