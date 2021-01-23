    public class HttpConnectorRequest<T> where T: class
    {
        public int Id { get; set; }
        public T RequestObject { get; set; }
        public string ResponseData { get; set; }
        public Exception Exception { get; set; }
    }
