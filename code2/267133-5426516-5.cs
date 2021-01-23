    public static T Deserialize<T>(XmlDocument xml)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        using (XmlReader reader = new XmlNodeReader(xml))
        {
            try
            {
                return (T)s.Deserialize(reader);
            }
            catch (Exception)
            {
                throw;
            }
        }
        throw new NotSupportedException();
    }
