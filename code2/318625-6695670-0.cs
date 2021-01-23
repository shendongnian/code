    private Cause _currentCause;
    public Cause CurrentCause
    {
        get { return _currentCause; }
        set
        {
            if (_currentCause == value) return;
                CurrentSolution = _currentCause.Solutions;  //However you do this...
            _currentCause = value;
            RaisePropertyChanged("CurrentCause");
        }
    }
    private ObservableCollection<Cause> _causes;
    public ObservableCollection<Cause> Causes
    {
        get { return _causes; }
        set
        {
            _causes = value;
            RaisePropertyChanged("Causes");
        }
    }
    private ObservableCollection<Solution> _solutions;
    public ObservableCollection<Solution> Solutions
    {
        get { return _solutions; }
        set
        {
            _solutions = value;
            RaisePropertyChanged("Companies");
        }
    }
    <dg:DataGrid ItemsSource="{Binding Causes}" SelectedItem="{Binding CurrentCause}"...
