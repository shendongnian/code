    [ServiceContract]
    public interface IMyService
    {
        [OperationContract(Name="GetCategoryObject")]
        UrlCategory2 GetCategoryObject(string url);
    }
    public class MyService : IMyService
    {
        public UrlCategory2 GetCategoryObject(string url)
        {
            return new UrlCategory2();
        }
    }
    [DataContract]
    public class UrlCategory2
    {
        [DataMember(Name="getCategory")]
        public string Category { get; set; }
    }
