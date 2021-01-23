    class MyClass
    {
        public string Name { get; set; }
    }
    class Syncronizer
    {
        public delegate void SynchronizatonEventHandler(MyClass myClass);
        internal event SynchronizatonEventHandler _onSyncFinished;
        public event SynchronizatonEventHandler OnSyncFinished
        {
            add
            {
                // Perform some code before the subscription.
                // Add the event.
                _onSyncFinished += value;
                // Perform some code after the subscription;
            }
            remove
            {
                // Perform some code before the subscription.
                // Remove the event.
                _onSyncFinished -= value;
                // Peroform some code after the subscription.
            }
        }
    }
