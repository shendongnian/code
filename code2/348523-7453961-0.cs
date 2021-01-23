    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, 
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class MessageService : IMessageService
    {
        public string ReturnMessage()
        {
            return String.Format("Thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
