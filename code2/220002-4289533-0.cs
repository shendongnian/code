    public imageList()
    {
        InitializeComponent();
        Images = new ObservableCollection<selectablePicture>();
        Images.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Images_CollectionChanged);
    }
