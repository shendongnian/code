    public T DoStuff<T>(string RawText)
    { 
        XmlSerializer ser = new XmlSerializer(typeof(T));
        object retObj;
        using (StringReader reader = new StringReader(RawText))
        {
            using (XmlTextReader xreader = new XmlTextReader(reader))
            {
                retObj = ser.Deserialize(xreader);
            }
        }
         return (T)retObj;
    }
