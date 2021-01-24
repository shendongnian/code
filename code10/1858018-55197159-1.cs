public class MyClass
{ 
  public MyClass(Func<bool> predicate)
  {
    this.Predicate = predicate;
  }
  public Func<bool> Predicate { get; }
}
var bah = new MyClass(() => foo > baz)
if (bah.Predicate())
{
}
