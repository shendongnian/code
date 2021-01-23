    public interface IEventRaiser<TEvent>
    {
        void Raise(TEvent e);
    }
    public class EventRaiser<TEvent> : IEventRaiser<TEvent>
    {
        List<IEventHandler<TEvent>> handlers;
        public EventRaiser(IEnumerable<IEventHandler<TEvent>> handlers)
        {
            this.handlers = handlers.ToList();
        }
        public void Raise(TEvent e)
        {
            handlers.ForEach(h => h.Handle(e));
        }
    }
