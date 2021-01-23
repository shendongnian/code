    // We declare a delegate to handle our event
    delegate void StateChangedEventHandler(object sender, StateChangedEventArgs e);
    // We declare event arguments class to specify, which value has changed to which value.
    public class StateChangedEventArgs: EventArgs
    {
        string propertyName;
        object oldValue;
        object newValue;
        /// <summary>
        /// This is a constructor.
        /// </summary>
        public StateChangedEventArgs(string propertyName, object oldValue, object newValue)
        {
            this.propertyName = propertyName;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
    }
    /// <summary>
    /// Our class that we wish to notify of state changes.
    /// </summary>
    public class Widget
    {
        private int x;
        public event StateChangedEventHandler StateChanged;
        // That is the user-defined property that fires the event manually;
        public int Widget_X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    int oldX = x;
                    x = value;
                    // The golden string which fires the event:
                    if(StateChanged != null) StateChanged.Invoke(this, new StateChangedEventArgs("x", oldX, x);
                }
            }
        }
    }
