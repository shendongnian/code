    public FooView MyFooView
    {
        get
        {
            return _myfooView;
        }
        set
        {
            if (value!= null)
            {
                _myfooView= value;
                RaisePropertyChanged(nameof(MyFooView));
            }
        }
    }
