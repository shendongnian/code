    class RequestCallbackStream
    {
        public Stream ResponseStream { get; private set; }
    
        public RequestCallbackState(Stream responseStream)
        {
            ResponseStream = responseStream;
        }
    }
