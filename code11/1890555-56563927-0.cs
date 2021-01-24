    public class ClassA
    {
        public async Task MyAsyncMethod()
        {
           return await LongProcessHere();
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
