    public sealed class AutoSyncServer : ObservableModel
        {
            public AutoSyncServer()
            {
                Port = "80";
                UserFriendlyName = "AutoSync Server";
                Server = "localhost";
            }
    
            private string _userFriendlyName;
            public string UserFriendlyName
            {
                get { return _userFriendlyName;}
                set
                {
                    _userFriendlyName = value;
                    OnPropertyChanged("UserFriendlyName");
                }
            }
