    enum OperationStatus
    {
       Unknown,
       Timeout,
       Ok
    }
    // pretty simple, only message and status code
    interface IOperationResult<T>
    {
          OperationStatus Status { get; }
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
        {    
            GetResponseResult result;  
            
            // wait for async request                 
            // ...
            if (timeout)
            {
              result = new GetResponseResult 
                            { 
                               Status = OperationStatus.Timeout,
                               Message = underlyingMessagingLib.ErrorMessage
                            };
            }
            else
            {
              result = new GetResponseResult 
                            { 
                               Status = OperationStatus.Ok,
                               Item = response
                            };
            }
            
            return result;
        }
    }
