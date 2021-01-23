    public static T Deserialize<T>(string json)
    {
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
          DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
          return (T)serializer.ReadObject(ms);
        }
    }
