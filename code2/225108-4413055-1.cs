    public class MyWebServiceWrapper
    {
       private static readonly object _lock = new object();
       public void CallWebService()
       {
          lock(_lock)
          {
             var objWebService = (ThirdPartWebService)Application["ThirdPartWebService"];
             objWebService.CallThatNeedsToBeSynchronized();
          }
       }
    }
