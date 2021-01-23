    public static string ToJsonString(object obj)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, obj);
            StringBuilder sb = new StringBuilder();
            sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
            return sb.ToString();
        }
    }
    public static T ToObjectFromJson<T>(string json)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
            return (T) serializer.ReadObject(ms);
        }
    }
