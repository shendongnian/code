    class EntityResult<T> {
        public EntityResult(T entity) {
            Success = true;
            Entity = entity;
        }
    
        public EntityResult(string error) {
            Success = false;
            Error = error;
        }
    
        bool Success {get; }
        T Entity { get; }
        string Error { get; }
    }
