    private int _numberOfTests ;
    public int NumberOfTests 
    {
        get { return _numberOfTests; }
        set
        {
            _numberOfTests = value;
            pqr();   // Your extra operations that run when any one changes NumberOfTests
            OnPropertyChanged();
        }
    }
