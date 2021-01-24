    public FooView MyFooView
    {
        get
        {
            return _myfooView;
        }
        set
        {
            if (_myfooView!= null)
            {
                _myfooView= value;
                RaisePropertyChanged(nameof(MyFooView));
            }
        }
    }
