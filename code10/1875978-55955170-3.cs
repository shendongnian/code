    public bool IsApproved
    {
        get
        {
            return _IsApproved;
        }
        set
        {
            if (_IsApproved != value)
            {
                _IsApproved = value;
                RaisePropertyChange("IsApproved");
                IsUpdated = true;
        }
    }
