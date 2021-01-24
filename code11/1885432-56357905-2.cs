public class Foo
{
   public Foo() {}
   public async Task LoginAsync() { ... }
}
var obj = new Foo();
await obj.LoginAsync();
In this approach, it wouldn't block the thread and it's better.
