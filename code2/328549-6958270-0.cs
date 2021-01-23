    public static T DeserializeFromFile<T>(string fileName) where T : class
    {
        using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }
