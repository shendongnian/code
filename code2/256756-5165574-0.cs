    protected override void Load(PhoneApplicationPage parent)
        {
           Verkeer.Helper.ExternalResources.RepeatAttemptExecuteMethod(() =>
                {
                    _appChannel = HttpNotificationChannel.Find(CHANNELNAME);
                    if (_appChannel == null)
                    {
                        _appChannel = new HttpNotificationChannel(CHANNELNAME);
                        SetUpDelegates();
                        
                    }
                    else
                    {
                        SetUpDelegates();
                        //if (_appChannel.ChannelUri != null) this.NotificationChannel = _appChannel.ChannelUri;
                    }
                    if (_appChannel.ChannelUri != null) this.NotificationChannel = _appChannel.ChannelUri;
                    else
                    {
                        try
                        {
                            _appChannel.Open();
                        }
                        catch { }
                    }
                     BindToShellTile();
                    App.ViewModel.TrafficInfo.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(TrafficInfo_PropertyChanged);
                    if (App.ViewModel.TrafficInfo.TrafficImage != null && this.NotificationChannel != null)
                    {
                        CreateTiles();
                    }
                },10);
        }
        private void BindToShellTile()
        {
            if (!_appChannel.IsShellTileBound && App.ViewModel.PanItemSettings.AutomaticallyUpdateTile)
            {
                Collection<Uri> ListOfAllowedDomains = new Collection<Uri> { new Uri("http://m.anwb.nl/") };
                _appChannel.BindToShellTile(ListOfAllowedDomains);
            }
        }
        void TrafficInfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TrafficImage")
            {
                if (App.ViewModel.PanItemSettings.AutomaticallyUpdateTile && this.NotificationChannel != null)
                {
                    CreateTiles();
                }
            }
        }
