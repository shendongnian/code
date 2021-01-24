    public interface IJsonParseService<T> where T : class
    {
         T ToObject(string json);
    }
    
    public class JsonParseService<T> : IJsonParseService<T> where T : class
    {
        public T ToObject(string json)
        {
          return JObject.Parse(json).Root.ToObject<T>();
        }
    }
