    public class MyService : IMyService
    {
      public void DoSomeOperation(SampleParam param)
      {
        using(UnitOfWork.Start())
        {
          //  do some work 
        }
      }
    }
