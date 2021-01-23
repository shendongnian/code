        protected string ObjectToXml<T>(T obj)
        {
            var sw = new StringWriter();
            try
            {
                var mySerializer = new XmlSerializer(typeof(T));
                mySerializer.Serialize(sw, obj);
            }
            catch (Exception ex)
            {
               // Error logging here
            }
            return sw.ToString();
        }
