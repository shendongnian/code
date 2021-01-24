    public readonly struct Either<TReturn, TError>
        where TReturn : struct
        where TError : struct
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
           _successful = truel
           _response = response;
        }
    }
