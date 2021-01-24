class Program
{
   private static Obj A = new Obj(...);
   private static void Function(Func<object[]> m)
   {
      object[] result = m();
      ...
   }
   static void main()
   {
      double a,b,c = 0;
      string d = " ";
      Function(() => A.MethodX(a,b,c));
      Function(() => A.MethodY(d,a,b));
      ...
   }
}
`Func<object[]>` is a delegate (broadly, a reference to a method) which does not take any parameters, and which returns an array of objects. While `MethodX` takes 3 parameters (`a,b,c`), we can create a new anonymous method without doesn't take any parameters itself, and which just calls `MethodX` and passes in the values of `a`, `b` and `c` (they're captured at the point that we create this new anonymous method). This is what `() => MethodX(a, b, c)` does.
------------
If you have different `Obj` instances and you want to control which one the method is called on, then use a `Func<Obj, object[]>`. This takes an `Obj` as a parameter, and returns an `object[]` as before.
class Program
{
   private static Obj A = new Obj(...);
   private static void Function(Func<Obj, object[]> m)
   {
      object[] result = m(A);
      ...
   }
   static void main()
   {
      double a,b,c = 0;
      string d = " ";
      Function(x => x.MethodX(a,b,c));
      Function(x => x.MethodY(d,a,b));
      ...
   }
}
