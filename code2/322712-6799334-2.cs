    private string _thumbFileName;
    public string ThumbFileName
    {
        get
        {
            return _thumbFileName;
        }
        set
        {
            _thumbFileName = value;
            OnNotifyChanged("ThumbFileName");
            OnNotifyChanged("ThumbImage");
        }
    }
    
    [IgnoreDataMember]
    public BitmapImage ThumbImage 
    { 
        get 
        { 
            BitmapImage image = new BitmapImage();                    
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            string isoFilename = ThumbFileName;
            var stream = isoStore.OpenFile(isoFilename, System.IO.FileMode.Open);
            image.SetSource(stream);
            return image;
        }     
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnNotifyChanged(string propertyChanged)
    {
        var eventHander = PropertyChanged;
        if (eventHander != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
