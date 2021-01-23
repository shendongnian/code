    private EventHandler SomeEventField;
    public void add_SomeEvent( EventHandler handler) {
        this.SomeEventField = (EventHandler)Delegate.Combine(this.SomeEvent, handler);
    }
    public void remove_SomeEvent( EventHandler ) {
       this.SomeEventField = (EventHandler)Delegate.Remove(this.SomeEvent, handler);
    }
