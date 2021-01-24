public void Foo(A a)
{
  if(a.GetType() == typeof(B))
  {
    Foo((B) a);
  }
  else if(a.GetType() == typeof(C))
  {
    Foo((C) a);
  }
  else if(a.GetType() == typeof(D))
  {
    Foo((D) a);
  }
}
so this is basically a general method which you can call with any object inheriting from A.
This is solution complies with the DRY (Don't Repeat Yourself) principles. 
If the idea is only to print which one it is you could also do it as follows:
public void Foo(A a)
{
  Console.WriteLine($"is {a.GetType().toString()}");
}
I used [string interpolation][1] here but you can also go without, it just looks a bit better if you ask me
And if you are a fancy man you can also add the function to the classes themselves as follows:
public abstract class A
{
  public abstract void Foo();
}
public class B : A
{
  public override void Foo()
  {
    Console.WriteLine("is b");
  }
}
public class C : A
{
  public override void Foo()
  {
    Console.WriteLine("is c");
  }
}
public class D : A
{
  public override void Foo()
  {
    Console.WriteLine("is d");
  }
}
Note that I made class A [abstract][2] here, since you don't actually make instances of A itself you can make the class abstract and only provide a 'template' for the actual functions which the inheriting members then [override][3].
I hope this helped, Good luck on your c# journey
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
