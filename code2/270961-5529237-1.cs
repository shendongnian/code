    class Komorka : INotifyPropertyChanged
        {
            private bool _state_opacity;
            private bool _state_color;
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            public bool state_color
            {
                get { return _state_color; }
                set
                {
                    _state_color = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("state_color"));
                    }; 
                }
            }
    
            public bool state_opacity
            {
                get
                {
                    return _state_opacity;
                }
                set
                {
                    _state_opacity = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("state_opacity"));
                    };
                }
            }
        }
    }
