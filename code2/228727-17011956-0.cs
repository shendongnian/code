    private string _numberDecimalSeparator;
    public string NumberDecimalSeparator
    {
        get
        {
            InitDefaultValues();
            return _numberDecimalSeparator;
        }
        set
        {
            InitDefaultValues(); 
            _numberDecimalSeparator = value;
        }
    }
...
    private void InitDefaultValues()
    {
        if (!_inited)
        {
            _inited = false;
            var ci = CultureInfo.CurrentCulture;
             _numberDecimalSeparator = ci.With(x => x.NumberFormat).Return(x => x.NumberDecimalSeparator, ".");
            
            ...
        }
    }
