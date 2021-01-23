    public class ResultStatus
    {
      public Int32 Id {get; protected set}
    
      public ErrorCode ErrorCode {get; protected set;}
    
      ReadonlyCollection<string> UserMessages {get; protected set;}
    
      protected ResultStatus (Int32 id, ErrorCode errorCode, List<string> userMessages)
      {
        Id = id;
        ErrorCode = errorCode;
        UserMessages = userMessages.AsReadOnly();
      }
    
      public static ResultStatus Success (int32 id, ErrorCode errorCode, List<string> userMessages)
     {
       ResultStatus resultStatus = new ResultStatus (id, errorCode, userMessages);
    
       return resultStatus;
    
     }
    }
