    // pretty simple, only message
    interface IOperationResult<T>
    {
          bool IsSuccess { get; }
          string Message { get; }
          T Item { get; }      
    }
    
    
    class GetResponseResult : IOperationResult<IEvent>
    {
       ...
    } 
    class EventManager
    {
        public IOperationResult<IEvent> GetResponseTo(
                                          IRequest request, 
                                          TimeSpan timeInterval)
    }
