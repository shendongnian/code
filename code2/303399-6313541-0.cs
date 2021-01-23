    interface IHttpResponseContent
    {
        void AddField(string name, string value);
    }
    class XmlHttpResponseMessage : HttpResponseMessage, IHttpResponseContent
    {
    }
