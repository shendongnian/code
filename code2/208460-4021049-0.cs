    public interface IMessageHandler
    {
        void HandleMessage(object sender, MessageAvailaibleEventArgs eventArgs);
    }    
    public abstract class ModelReader : IDisposable
    {
        private readonly IMessageHandler handler; // Should be initialized somewhere, e.g. in constructor
        public abstract Model Read();
    
        public event EventHandler<MessageAvailableEventArgs> MessageAvailable;
    
        protected virtual void RaiseError(string message)
        {
            MessageAvailaibleEventArgs eventArgs =
                new MessageAvailaibleEventArgs(TraceEventType.Error, message);
            this.handler.HandleMessage(this, eventArgs);
        }
    }
