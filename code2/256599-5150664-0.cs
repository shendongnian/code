    public class AbstractEnum<T> where T : AbstractEnum<T>
    {
       ...
       private static IEnumerable<T> ValuesInternal {
            get {
                return nameRegistry.Values;
            }
       }
    
       public IEnumerable<T> Values {
         get {
           return ValuesInternal;
         }
       }
    }
