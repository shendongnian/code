    public interface IMyWebRequest
    {
        Stream GetRequestStream();
        WebResponse GetResponse();
        IAsyncResult BeginGetResponse(AsyncCallback callback, object state);
        WebResponse EndGetResponse(IAsyncResult asyncResult);
        IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state);
        Stream EndGetRequestStream(IAsyncResult asyncResult);
        void Abort();
        RequestCachePolicy CachePolicy { get; set; }
        string Method { get; set; }
        Uri RequestUri { get; }
        string ConnectionGroupName { get; set; }
        WebHeaderCollection Headers { get; set; }
        long ContentLength { get; set; }
        string ContentType { get; set; }
        ICredentials Credentials { get; set; }
        bool UseDefaultCredentials { get; set; }
        IWebProxy Proxy { get; set; }
        bool PreAuthenticate { get; set; }
        int Timeout { get; set; }
        AuthenticationLevel AuthenticationLevel { get; set; }
        TokenImpersonationLevel ImpersonationLevel { get; set; }
        object GetLifetimeService();
        object InitializeLifetimeService();
        ObjRef CreateObjRef(Type requestedType);
    }
