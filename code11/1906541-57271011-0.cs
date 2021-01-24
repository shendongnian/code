cs
public void Foo()
{
   string bar = "Bar";
   Action action = x => Console.WriteLine(bar);
   action();
}
It will convert it to something like the following:
cs
private sealed class Helper {
  public string bar;
  public void action()
  {
     Console.WriteLine(bar);
  }
}
  [1]: https://youtu.be/gc1AxbNybvw?t=1606
