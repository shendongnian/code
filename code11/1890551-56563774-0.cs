c#
public class ClassA
{
    public Task MyAsyncMethod()
    {
        await LongProcessHere();
    }
}
public class MyCaller()
{
   private async Task ExecuteAsync()
   {
      ClassA ca = new ClassA();
      await ca.MyAsyncMethod();
   }
}
