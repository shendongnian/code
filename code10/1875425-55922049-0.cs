    public string TotalStarthh
    {
        get { return _TotalStarthh; }
        set 
        {
             _TotalStarthh = value;
             NotifyPropertyChanged(); // notifies the UI this property has changed
             NotifyPropertyChanged("IsTimeValid"); // notifies the UI IsTimeValid has changed 
        }
    }
