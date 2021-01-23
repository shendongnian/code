    // Delegate type for the event handler
    public delegate void MyEventHandler();
    // Declare the event.
    public event MyEventHandler MyEvent;
    // In the properties or any place you what to notify of change:
    if (MyEvent != null)
          MyEvent();
