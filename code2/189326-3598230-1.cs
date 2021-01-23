    public class MyCSharpProgram
    {
        // ...
        // define the event
        public event EventHandler SomeEvent;
        // add a mechanism to "raise" the event
        protected virtual void OnSomeEvent()
        {
            // SomeEvent is a "variable" to a EventHandler
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);
        }
    }
    // etc...
