    private string _Weight;
    public string Weight
        {
            get => _Weight;
            set
            {
                if (_Weight != value)
                {
                    _Weight = value;
                    OnPropertyChanged();
                }
            }
        }
