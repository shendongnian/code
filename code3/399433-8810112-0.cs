    private string _ImageID;
    public string ImageID
    {
        get
        {
            return _ImageID;
        }
        set
        {
            _ImageID = value.Trim();
            NotifyPropertyChanged("_ImageID");
        }
    }
