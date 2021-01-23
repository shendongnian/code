    public static IList<T> GetAllItems<T>()
    {
        XmlSerializer deSerializer = new XmlSerializer(typeof(List<T>));
    
        using(TextReader tr = new StreamReader(GetPathBasedOnType(typeof(T))))
        {
            IList<T> items = (IList<T>)deSerializer.Deserialize(tr);
        }
    
        return items;
    }
