    public class Result<T>
    {
      public T Value { get; set; }
      
      public static Result<T> operator * (Fraction<T> a, Fraction<T> b)
      {
        // Multiply Logic
      }
    }
