    public static T LoadFromFile<T>(String fileName, Boolean ensureExists)
    {
        String dbFile = Path.Combine(Application.StartupPath, fileName);
        if (!File.Exists(dbFile))
            if (ensureExists)
                throw new FileNotFoundException("File not Found!");
            else return default(T);
        using (Stream stream = File.Open(dbFile, FileMode.Open))
        {
            if (stream.Length > 0)
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                return (T)bFormatter.Deserialize(stream);
            }
        }
    }
