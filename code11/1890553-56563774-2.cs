c#
public class ClassA
{
    // always return a Task from an async method 
    public async Task MyAsyncMethod()
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
