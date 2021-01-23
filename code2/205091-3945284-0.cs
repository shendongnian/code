    private EventHandler eventField;
    
    public event EventHandler SomeEvent
    {
      add { eventfield = Delegate.Combine(eventfield, value); }
      remove { eventfield = Delegate.Remove(eventfield, value); }
    }
