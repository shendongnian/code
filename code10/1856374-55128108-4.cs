    using System.ComponentModel;
    namespace WpfApp1
    {
        class VM : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private bool connected; 
            public bool Connected
            {
                get { return connected; }
                set
                {
                    {
                        connected = value;
                        OnPropertyChanged("Connected");
                        if (value) { ConnectOrDisconnect = "Disconnect"; }
                        else { ConnectOrDisconnect = "Connect"; }
                    }
                }
            }
            private string connectOrDisconnect;
            public string ConnectOrDisconnect
            {
                get { return connectOrDisconnect; }
                set
                {
                    connectOrDisconnect = value;
                    OnPropertyChanged("ConnectOrDisconnect");
                }
            }
            public VM()
            {
                Connected = false;
            }
            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
