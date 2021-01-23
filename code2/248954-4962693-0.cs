        class Data : INotifyPropertyChanged
        {
            Manager _manager;
            
            public Data(Manager manager)
            {
                _manager = manager;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            String _info = "Top Secret";
            public String Information
            {
                get { return _info; }
                set 
                {
                    _info = value;
    
                    if (!_manager.Paused)
                    {
                        PropertyChangedEventHandler handler = PropertyChanged;
                        if (handler != null)
                            handler(this, new PropertyChangedEventArgs("Information"));
                    }
                }
            }
        }
