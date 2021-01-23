    public interface IAllowReferenceTypes<T>
    {
       T GetValue();
    }
    public class SomeClass : IAllowReferenceTypes<Int32?>
    {
       public Int32? GetValue() { return null; }
    }
 
