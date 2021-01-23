    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(
          Method = "GET",
          UriTemplate = "/magic")]
        void MagicMethod();
    }
