public class Foo : IDisposable
{
   public void Dispose() { //Clean up  here}
}
using (foo = new Foo() ) { //consume foo here  }
