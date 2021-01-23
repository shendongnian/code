    public class ValidationType<T>
    {
       public T Value {get; set;}
       public string Warning {get; set;}
       public string Error {get; set;}
       public ValidationType(T value)
       {
          Value = value;
       }
    }
