    private IEnumerable<DataPoint> _DataPoints;
    public IEnumerable<DataPoint> DataPoints
    {
        get
        {
            return _DataPoints;
        }
        set
        {
            if (_DataPoints != value)
            {
                _DataPoints = value;
                this.OnPropertyChanged("DataPoints");
            }
        }
    }
