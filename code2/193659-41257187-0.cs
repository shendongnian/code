    public T GetFromXml<T>(string xml)
        where T: class, new()
    {
        if (String.IsNullOrEmpty(xml))
        {
            return new T();
        }
        return xml.AsObjectFromXml<T>();
    }
