 c#
public static void MyMethod(params Action[] funcs)
{
   foreach (var func in funcs)
   {
      func();
   }
}
public static void Print1<T>(params T[] objs)
{
   Console.WriteLine("==== I am in 1 ====");
}
public static void Print2<T>(params T[] objs)
{
   Console.WriteLine("==== I am in 2 ====");
}
static void Main()
{
   MyMethod(
      () => Print1(1, 2, 3),
      () => Print2("1", "2", "3")
   );
}
In particular: the `<T>` is not common between the two calls, so it cant be generic on `MyMethod`; fine in `Print1<T>` and `Print2<T>` though, as the respective `<T>` is specified (implied) in the lambda. 
