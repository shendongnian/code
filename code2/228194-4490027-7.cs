    class CallResult<T> where T : class {
      public CallResult(T result) { Result = result; }
      public CallResult(Exception exception) { Exception = exception; }
      public T Result { get; private set; }
      public Exception Exception { get; private set; }
      public Boolean IsSuccessful { get { return Exception == null; } }
    }
