    private ObservableCollection<Point> _points;
    public ObservableCollection<Point> points
    {
        get { return _points; }
        set
        {
            _points = value;
            OnPropertyChanged(nameof(points));
        }     
    }
