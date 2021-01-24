    public class Result<T>
    {
      public T Value { get; set; }
      
      public static Result<T> operator * (Result<T> a, Result<T> b)
      {
        // Multiply Logic
      }
    }
