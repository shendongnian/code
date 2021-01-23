    public static void Serialize(String path, MovieList movieList)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MovieList));
    
        using (StreamWriter streamWriter = new StreamWriter(path))
        {
           serializer.Serialize(streamWriter, movieList);
        }
    }
    
    public static MovieList Deserialize(String path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MovieList));
        using (StreamReader streamReader = new StreamReader(path))
        {
            return (MovieList) serializer.Deserialize(streamReader);
        }
    }
