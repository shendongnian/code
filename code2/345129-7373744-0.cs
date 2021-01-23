    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ILogCallback))]
    public interface ILog
    {
      void PushOnTheClient();
    }
    
    public class MyLog : ILog
    {
      void PushOnTheClient()
      {
            ILogCallback callbacks = OperationContext.Current.GetCallbackChannel<ILogCallback>();
            callbacks.Push(s);
      }
    }
