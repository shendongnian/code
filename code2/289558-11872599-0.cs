    public interface IGraphResponse<T> where T : class
    {
        List<T> Data { get; set; }
    }
  
    public class GraphResponse<T> : IGraphResponse<T> where T : class
    {
       [JsonProperty("data")]
       public List<T> Data { get; set; }
    }
