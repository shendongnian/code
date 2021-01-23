namespace WcfAsyncTest
{
    [ServiceContract]
    public interface IAsyncTest
    {
        [OperationContract(AsyncPattern=true)]
        IAsyncResult BeginOperation(AsyncCallback callback, object state);
        
        string EndOperation(IAsyncResult ar);
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IAsyncTest
    {
        public IAsyncResult BeginOperation(AsyncCallback callback, object state)
        {
            Task result = Task.Factory.StartNew((x) =>
                {
                    // spin to simulate some work
                    var stop = DateTime.Now.AddSeconds(10);
                    while (DateTime.Now < stop)
                        Thread.Sleep(100);
                }, state);
            if (callback != null)
                result.ContinueWith(t => callback(t));
            return result;
        }
        public string EndOperation(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.WaitOne();
            return "Hello!!";
        }
    }
}
