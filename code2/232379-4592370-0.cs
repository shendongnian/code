    public abstract class RegistrationValue
    {
    }
    
    public class RegistrationValue<T> : RegistrationValue
    {
      public RegistrationValue(T value)
      {
        Value = value;
      }
    
      public T Value { get; private set; }
    }
