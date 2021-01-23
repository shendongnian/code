    // event delegate handler
    public delegate void MyNewEventHandler(object s, MyNewEventArgs e);
    // your control class
    public class MyControl : Control
    {
      // expose an event to attach to.
      public event MyNewEventHandler MyNewEvent;
