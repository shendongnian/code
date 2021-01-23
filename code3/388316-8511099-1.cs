    public interface IMessageSource
    {
        event Action<string> OnMessage;
    }
    public class MessageSource : IMessageSource
    {
        public event Action<string> OnMessage;
        public void Send(string m)
        {
            if (OnMessage!= null) OnMessage(m);
        }
    }
    public class Terminal : IDisposable
    {
        private IList<IMessageSource> sources = new List<IMessageSource>();
        public void Subscribe(IMessageSource source)
        {
            source.OnMessage += Broadcast;
            sources.Add(source);
        }
        void Broadcast(string message)
        {
            Console.WriteLine(message);
        }
        public void Dispose()
        {
            foreach (var s in sources) s.OnMessage -= Broadcast;
        }
    }
