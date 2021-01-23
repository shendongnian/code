    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Search/{name}", BodyStyle = WebMessageBodyStyle.Bare)]
        string  GetGreeting(string name);
    }
