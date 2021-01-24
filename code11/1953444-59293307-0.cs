csharp
public class FooContainer
{
   private Foo _myFoo;
   public IFoo MyFoo => _myFoo;
}
public class Foo : IFoo
{
   //This is visible in your public API
   public bool NonSensitiveFlag { get; private set; }
   public string NonSensitiveString { get; private set; }
   //This is not visible due to not being present in IFoo definition
   public string MySensitiveString { get; set; }
}
public interface IFoo
{
   bool NonSensitiveFlag { get; }
   string NonSensitiveString { get; }
}
