    public FooView MyFooView
    {
        get
        {
            return _myfooView;
        }
        set
        {
            _myfooView= value;
            RaisePropertyChanged(nameof(MyFooView));
        }
    }
