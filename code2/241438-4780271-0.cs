    private EventHandler myEvent;
    public event EventHandler MyEvent
    {
        add
        {
            myEvent += value;
            SomeClass.AnotherEvent += value;
        }
        remove
        {
            myEvent -= value;
            SomeClass.AnotherEvent -= value;
        }
    }
