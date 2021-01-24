    enum RequestState
    {
        Requested,
        InProgress,
        Declined,
        Finished
    }
    public class Request
    {
        private RequestState _state = RequestState.Requested;
        public void BeginWork()
        {
            if (_state == RequestState.Declined || _state == RequestState.Finished)
                throw new InvalidOperationException("You can only begin work on a new request.");
            _state = RequestState.InProgress;
        }
        
        public void Decline()
        {
            if (_state == RequestState.Finished)
                throw new InvalidOperationException("Too late - it's finished!");
            _state = RequestState.Declined;
        }
        // etc.
    }
