    public class Wrapper<TValue>
    {
        public TValue Value { get; set; }
    }
    public struct Foostruct
    {
        private Wrapper<Tick> _tick;
    
        public Tick Tick
        {
            get { return _tick == null ? new Tick(20) : _tick.Value; }
            set { _tick = new Wrapper<Tick> { Value = value }; }
        }
    }
