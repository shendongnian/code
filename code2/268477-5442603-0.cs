    // Provide a way to wait for the value to be read;
    // Initially, the variable can be set.
    private AutoResetEvent _event = new AutoResetEvent(true);
    // Make the field private so that it can't be changed outside the setter method
    private static int _yourField;
    public static int YourField {
        // "AutoResetEvent.Set" will release ALL the threads blocked in the setter.
        // I am not sure this is what you require though.
        get { _event.Set(); return _yourField; }
        // "WaitOne" will block any calling thread before "get" has been called.
        // except the first time
        // You'll have to check for deadlocks by yourself
        // You probably want to a timeout in the wait, in case
        set { _event.WaitOne(); _yourField = value; }
    }
