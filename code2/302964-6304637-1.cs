    public class MyEvent: Event
    {
        private Action _action;        
        public MyEvent(int milliseconds, Action action)
            : base(milliseconds)
        {
            _action= action;
        }
        public override void doWork()
        {
            action()
        }
    }
