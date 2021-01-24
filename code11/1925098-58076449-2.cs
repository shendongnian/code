    public readonly class Either<TReturn, TError>
    {
        bool _successful;
        private TError _error { get; }
        private TReturn _response { get; }
    
        public Either(TError error)
        {
            _error = error;
        }
    
        public Either(TReturn response)
        {
           _successful = true;
           _response = response;
        }
    }
