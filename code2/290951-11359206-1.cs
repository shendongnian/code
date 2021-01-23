    public String ConnectedSystemName
    {
        get { return _connectedSystem.Name; }
        set
        {
            _connectedSystem.Name = value;
            NotifyOfPropertyChange(() => _connectedSystem.Name);
        }
    }
