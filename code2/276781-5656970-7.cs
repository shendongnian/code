    public class MyController : AsyncController
    {
        [NoGzip]
        [NoAsyncTimeout]
        public void GetProgress(int id)
        {
            AsyncManager.OutstandingOperations.Increment();
            ...
        }
        
        public ActionResult GetProgressCompleted() 
        {
            ...
        }
    }
