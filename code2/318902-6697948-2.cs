    public class MockDialogService : IDialogService
    {
       private object Result;
       public MockDialogService(object result)
       {
          Result = result;
       }
       public object GetValueFromDialog() { return Result; }
    }
