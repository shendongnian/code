    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ProcessRequest;ID={id}")]
        XmlElement ProcessRequest(string id, Stream postbody);
    }
