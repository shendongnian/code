    public class MyService
    {
        [OperationContract]
        [WebGet(UriTemplate = "search?q={keyword}&op=xml")]
        string GetXml(string keyword);
            
        [OperationContract]
        [WebGet(UriTemplate = "search?q={keyword}&op=json")]
        string GetJson(string keyword);
    }
