C#
interface IMyInterface 
{
  void Foo();
  Task FooAsync();
}
class MyImplementation1 : IMyInterface
{
  public void Foo() => Foo(sync: true).GetAwaiter().GetResult();
  public Task FooAsync() => Foo(sync: false);
  private async Task Foo(bool sync)
  {
    // Pass `sync` along to all methods that can be sync or async.
    await OtherMethod1(sync);
    await OtherMethod2(sync);
    await OtherMethod3(sync);
    await OtherMethod4(sync);
  }
  private async Task OtherMethod1(bool sync)
  {
    // When you have to choose sync/async APIs of other classes, then choose based on `sync`.
    if (sync)
      Thread.Sleep(1000); // synchronous placeholder
    else
      await Task.Delay(1000); // asynchronous placeholder
  }
}
  [1]: https://msdn.microsoft.com/en-us/magazine/mt238404.aspx
