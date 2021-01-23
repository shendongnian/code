    private MyEventDelegateClass __cgbe_MyEvent; // Compiler generated backing field
    public event MyEventDelegateClass MyEvent
    {
        add
        {
            this.__cgbe_MyEvent = (MyEventDelegateClass)Delegate.Combine(this.__cgbe_MyEvent, value);
        }
        remove
        {
            this.__cgbe_MyEvent = (MyEventDelegateClass)Delegate.Remove(this.__cgbe_MyEvent, value);
        }
        get
        {
            return this.__cgbe_MyEvent;
        }
    }
