    public CustomerUpdateViewModel(IEventAggregator events)
    {
            _events = events;
            _events.Subscribe(this);
    }
