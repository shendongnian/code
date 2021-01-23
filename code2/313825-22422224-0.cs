    public $PropertyType$ $PropertyName$
    {
        get { return _$variableName$; }
    
        set
        {
            if (_$variableName$ != value)
            {
                _$variableName$ = value;
                RaisePropertyChanged(() => $PropertyName$);
            }
        }
    }
