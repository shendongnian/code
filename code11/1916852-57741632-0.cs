    public string ServiceName
    {
        get { return _serviceName; }
        set
        {
            _serviceName = value;
            EventAggregator.GetEvent<eventname>().Publish(_serviceName);
        }
    }
