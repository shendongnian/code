    public abstract class HPCRequest<TRequest>
      where TRequest: class
    {
        public delegate void RequestCompleteHandler(TRequest request);
        public event RequestCompleteHandler<TRequest> RequestComplete;
    }
    public sealed class HPCGetConfig : HPCRequest<HPCGetConfig>
    {
    }
