    public void LoadCustomers()
    {
        _customerService.GetCustomers()
            .SubscribeOn(Scheduler.NewThread)
            .ObserveOn(Scheduler.Dispatcher, DispatcherPriority.SystemIdle)
            .Subscribe(Customers.Add);
    }
