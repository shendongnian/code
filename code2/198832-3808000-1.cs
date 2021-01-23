    [OperationContract]
    [WebGet(UriTemplate = "GetData?param1={i}&param2={s}")]
    [DynamicResponseType]
    public SampleResponseBody GetData(int i, string s)
    {
        return new SampleResponseBody() 
                   { 
                      Name = "Test",
                      Value = s, 
                      Time = DateTime.Now.ToShortTimeString() 
                   };
    }
