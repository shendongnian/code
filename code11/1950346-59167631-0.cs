C#
class Something : IInterfaceA, IInterfaceB {
   public IInterfaceA A => this;
   public IInterfaceB B => this;
}
...
something.A.AMethod();
something.B.BMethod();
You might also consider using extension methods instead of default implementations. They are somewhat similar anyway.
C#
interface IInterface {
}
static class IInterfaceExtensions {
   public static void DoSomething(
      this IInterface me
   ) {
      // do something
   }
}
