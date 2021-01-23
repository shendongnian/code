    public class AbstractEnum<T> where T : AbstractEnum<T>
    {
       ...
       protected static IEnumerable<T> ValuesInternal {
            get {
                return nameRegistry.Values;
            }
       }
    }
    
    public class SomeEnum : AbstractEnum<SomeEnum> {
      ...
    
      public static IEnumerable<SomeEnum> Values
      {
        get
        {
            return ValuesInternal;
        }
    
      }
    }
