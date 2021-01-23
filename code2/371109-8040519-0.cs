    public class MessageEvent : CompositePresentationEvent<Message>{}
    internal class MessageReceiver
    {
        private readonly MessageEvent _evt;
        private readonly string _myId = Guid.NewGuid().ToString();
        internal MessageReceiver(IEventAggregator eventAggregator)
        {
            _evt = eventAggregator.GetEvent<MessageEvent>();
            _evt.Subscribe(Receive, true);
            _evt.Publish(new Message { Source = _myId, Command = Message.Commands.WhoIAm });
        }
        public void Receive(Message message)
        {
            switch (message.Command)
            {
                case Message.Commands.WhoIAm:
                    _evt.Publish(
                        new Message
                        {
                            Destination = message.Source,
                            Command = Message.Commands.Initialize,
                            MessageData = Encoding.UTF8.GetBytes("init data")
                        });
                    break;
                case Message.Commands.Initialize:
                    if (message.Destination == _myId)
                    {
                        //init
                    }
                    break;
            }
        }
    }
    public class Message
    {
        public enum Commands { Initialize, WhoIAm }
        public string Source { get; set; }
        public string Destination { get; set; }
        public Commands Command { get; set; }
        public byte[] MessageData { get; set; }
    }
