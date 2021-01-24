public Login() {
  Task.Run(() => this.loginAsync()).Wait();
}
Be careful, this solution synchronously blocks the thread.
Update 1:
Don't put initialization code in your constructor, instead do it like below:
public class Foo
{
   public Foo() {}
   public async Task LoginAsync() { ... }
}
var obj = new Foo();
await obj.LoginAsync();
In this approach it wouldn't block the thread and it's better.
