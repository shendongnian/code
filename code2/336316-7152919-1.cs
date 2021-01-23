    public class MockConfirmationDialogService : IConfirmationDialogService
    {
       public MockConfirmationDialogService(bool result)
       {
          _Result = result;
       }
       private bool _Result;
       public bool Show(string question)
       {
          return _Result;
       }
    }
