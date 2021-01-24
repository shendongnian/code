    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string PropertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
    private bool _isConnected;
    public bool IsConnected
    {
        get
        {
            return _isConnected;
        }
        set
        {
            _isConnected = value;
            OnPropertyChanged();
        }
    }
     NetworkHelper.Instance.NetworkChanged += Instance_NetworkChanged;
     private async void MainPage_Loaded(object sender, RoutedEventArgs e)
     {
         if (NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable)
         {
             await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 IsConnected = true;
             });
    
         }
     }
    
     private async void Instance_NetworkChanged(object sender, EventArgs e)
     {
         if (NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable)
         {
             await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 IsConnected = true;
             });
         }
         else
         {
             await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 IsConnected = false;
             });
         }
     }
