    private DateTime _changeDate;
    public DateTime ChangeDate
    {
        get { return _changeDate; }
        set { _changeDate = value; NotifyPropertyChanged(); }
    }
