    class SomeEventSource
    {
        public event EventHandler<SomeEventArgs> MyEvent;
        public void FireTheEvent()
        {
            MyEvent(this, new SomeEventArgs("This information is interesting"));
        }
    }
    class SomeEventArgs : EventArgs
    {
        public SomeEventArgs(string interestingInformation)
        {
            InterestingInformation = interestingInformation;
        }
        public string InterestingInformation { get; private set; }
    }
