    public class DoSomething2:IMyInterface
    {
         public async Task DoSomethingAsync()
         {
             await Task.Run(()=>doSomethingElse());
         }
    }
