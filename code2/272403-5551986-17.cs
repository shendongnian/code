    public string Name
    {
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("NameBrush");
            }
        }
    }
    
    public Brush NameBrush
    {
        get
        {
            switch (Name)
            {
                case "John":
                    return Brushes.LightGreen;
                default:
                    break;
            }
    
            return Brushes.Transparent;
        }
    }
