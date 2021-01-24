      public CustomerViewModel(IEventAggregator events, IWindowManager windowManager, CustomerUpdateViewModel customerUpdateVM)
        {
            _windowManager = windowManager;
            _customerUpdateVM = customerUpdateVM;
            _events = events;
            _events.Subscribe(this);
        }
