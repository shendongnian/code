    [ServiceContract]
    public interface IMyService
    {
        [OperationContract(Name="GetCategoryObject")]
        UrlCategory2 GetCategoryObject(string url);
        [DataMember(Name="getCategory")]
        public string Category { get; set; }
    }
