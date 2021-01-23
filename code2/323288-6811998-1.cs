    public static T Clone<T>(this T source)
    {
        if (source == default(T))
        {
            return default(T);
        } else {
            IFormatter formatter = new BinaryFormatter();
            Stream ms = new MemoryStream();
            using (ms)
            {
                formatter.Serialize(ms, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(ms);
            }
        }
    }
