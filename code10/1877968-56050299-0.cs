    private ObservableCollection<AcquisitionDeviceInfo> _observableAcquisitionDevices;
    private ObservableCollection<string> ObservableDevices { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        
        ObservableDevices = new ObservableCollection<string>();
        _observableAcquisitionDevices = new ObservableCollection<AcquisitionDeviceInfo>();
        _observableAcquisitionDevices.CollectionChanged += AquisitionDevices_CollectionChanged;
        
        // set the data context after the property we are binding to is set
        // especially if you don't have property change support in place
        DataContext = this;
        // add data to _observableAcquisitionDevices
    }
    
    private void AquisitionDevices_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
        {
            for each (var device in e.OldItems.OfType<AcquisitionDeviceInfo>().Device)
            {
                ObservableDevices.Remove(device);
            }
        }
        if ((e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace) && e.NewItems != null)
        {
            for each (var device in e.NewItems.OfType<AcquisitionDeviceInfo>().Device)
            {
                ObservableDevices.Add(device);
            }
        }
        if (e.Action == Reset)
        {
            ObservableDevices.Clear();
        }
    }
