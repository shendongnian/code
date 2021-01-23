    public static IList<T> GetAllItems<T>() //Note T is now a type agrument
    {
        //the using statement is better practice than manual Close()
        using (var tr = new StreamReader(GetPathBasedOnType(typeof(T)))) 
           return (List<T>)new XmlSerializer(typeof(List<T>)).Deserialize(tr);
    }
