    public class HttpConnectorRequest
    {
        // Other members elided
        public void SetRequestObject<T>(T value) where T : class
        {
            ...
        }
        public T GetRequestObject<T>() where T : class
        {
            ...
        }
    }
