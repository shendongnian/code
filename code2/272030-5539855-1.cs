    public class EventConsumer
    {
        private EventExample eventExample;
        public EventConsumer()
        {
            eventExample = new EventExample();
            //register a handler with the event here
            eventExample.ApplyAccepted += new EventHandler<EventExample.ApplyEventArgs>(eventExample_EventName);
        }
        void eventExample_EventName(object sender, EventExample.ApplyEventArgs e)
        {
            //respond to event here
        }
    }
