    public interface IDataResponse<T> where T : class
    {
        List<T> Data { get; set; }
    }
  
    public class DataResponse<T> : IDataResponse<T> where T : class
    {
       [JsonProperty("data")]
       public List<T> Data { get; set; }
    }
