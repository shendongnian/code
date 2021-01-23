    public struct TransitionResult<TState>
    {
        public TransitionResult(TState newState, bool isValid)
        {
            NewState = newState;
            IsValid = isValid;
        }
        public TState NewState;
        public bool IsValid;
    }
