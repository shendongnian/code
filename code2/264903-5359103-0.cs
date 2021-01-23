    private Visibility _longDescriptionVisibility;
    public Visibility LongDescriptionVisibility
    {
        get { return _longDescriptionVisibility; }
        set
        {
            _longDescriptionVisibility = value;
            NotifyPropertyChanged("LongDescriptionVisibility");
        }
    }       
