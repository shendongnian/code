    /// <summary>
    /// Inherit from this class and you will get an event that people can subsribe
    /// to plus an easy way to raise that event.
    /// </summary>
    public abstract class BaseClassThatCanRaiseEvent
    {
        /// <summary>
        /// This is a custom EventArgs class that exposes a string value
        /// </summary>
        public class StringEventArgs : EventArgs
        {
            public StringEventArgs(string value)
            {
                Value = value;
            }
            public string Value { get; private set; }
        }
        //The event itself that people can subscribe to
        public event EventHandler<StringEventArgs> NewStringAvailable;
        /// <summary>
        /// Helper method that raises the event with the given string
        /// </summary>
        protected void RaiseEvent(string value)
        {
            var e = NewStringAvailable;
            if(e != null)
                e(this, new StringEventArgs(value));
        }
    }
