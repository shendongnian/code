    private string _myProperty;
    public virtual string MyProperty
    {
        get { return _myProperty; }
        set
        {
            _myProperty = value;
            OnPropertyChanged(nameof(MyProperty)); // or however your base view-model class method signature for raising the event
        }
    }
