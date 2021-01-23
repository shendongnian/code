    public class EventMessageHandler : IMessageHandler
    {
        public event EventHandler<MessageAvailaibleEventArgs> MessageAvailable;
    
        public void HandleMessage(object sender, MessageAvailaibleEventArgs eventArgs)
        {
            var handler = this.MessageAvailable;
            if (handler != null)
            {
                handler(this, new MessageAvailaibleEventArgs(
                    TraceEventType.Error, message);
            }
        }
    }
