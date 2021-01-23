    #if DEBUG
    [TraceExtension]
    #endif
    [System.Web.Service.Protocols.SoapDocumentMethodAttribute( ... )]
    [ more attributes ...]
    public DatabaseResponse[] GetDatabaseResponse( ...) 
    {
        object[] results = this.Invoke("GetDatabaseResponse",new object[] {
              ... parmeters}};
    }
    #if DEBUG
    [TraceExtension]
    #endif
    public System.IAsyncResult BeginGetDatabaseResponse(...)
    #if DEBUG
    [TraceExtension]
    #endif
    public DatabaseResponse[] EndGetDatabaseResponse(...)
