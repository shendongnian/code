    public class SomeBusinessView
    {
        private readonly IEventHub _events = null;
        // we cannot function without an event aggregator of
        // some kind, so we declare our dependency as a contructor
        // dependency
        public SomeBusinessView (IEventHub events)
        {
            _events = events;
        }
        public void DoMyThang ()
        {
            // 1. do some business
            MyBusinessData data = SomeBusinessFunction ();
            // 2. publish complete event
            AnalysisSubject subject = new AnalysisSubject () { Data = data, };
            _events.Publish (subject);
        }
    }
