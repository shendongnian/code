    public interface IJsonSerializer
    {
        string SerializeObject(object obj);
        object DeserializeObject(string json, Type type);
        T DeserializeObject<T>(string json);
        object DeserializeObject(string json);
    }
