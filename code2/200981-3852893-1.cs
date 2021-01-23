    public class CustomException : System.Exception
    {
      public CustomException()
      {
      }
      
      public CustomException(string message)
        : base(message)
      {
      }
      
      public CustomException(string message, System.Exception innerException)
        : base(message, innerException)
      {
      }
    }
