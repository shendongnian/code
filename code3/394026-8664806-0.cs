    // Create some custom arguments for the event
    public class SampleEventArgs
    {
        public SampleEventArgs(string s) 
        { 
            Text = s; 
        }
        public String Text {get; private set;} 
    }
 
    // Define a class that uses the event
    public class EventPublisher
    {
        // Declare the delegate 
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);
        // Declare the event.
        public event SampleEventHandler SampleEvent;
        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseSampleEvent()
        {
            // Raise the event by using the () operator.
            if (SampleEvent != null)
                SampleEvent(this, new SampleEventArgs("Hello"));
        }
    }
