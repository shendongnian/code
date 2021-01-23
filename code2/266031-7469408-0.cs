    [WebInvoke(ResponseFormat = WebMessageFormat.Json, 
               RequestFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.WrappedRequest,
               Method = "POST",
               UriTemplate = "setExpositions?shelfId={shelfId}")]
    [OperationContract]
    public bool SetExpositions(int shelfId, List<WcfExposition> expositions)
    {
    }
