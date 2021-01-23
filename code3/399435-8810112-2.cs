    private string _ImageID;
    public string ImageID
    {
        get
        {
            return _ImageID;
        }
        set
        {
           value = (value == null ? value : value.Trim());
           NotifyPropertyChanged("ImageID");
        }
    }
