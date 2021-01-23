    class CallResult {
      public CallResult(OutType result) { Result = result; }
      public CallResult(Exception exception) { Exception = exception; }
      public OutType? Result { get; private set; }
      public Exception Exception { get; private set; }
      public Boolean IsSuccessful { get { return Exception == null; } }
    }
