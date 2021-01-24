    public string abbr {
            get 
            { 
                return _abbr; 
            }
            set 
            { 
                if (_abbr != value) {
                    _abbr = value;
                    OnPropertyChanged("abbr");
                }
            } 
    
    }
