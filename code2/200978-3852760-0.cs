    public class MyException : System.Exception
    {
         public MyException() : base() { }
         public MyException(string message) : base(message) { }
         public MyException(string message, Exception innerException) : base(message, innerException) { }
    }
