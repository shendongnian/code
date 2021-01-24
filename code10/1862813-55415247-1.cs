    internal bool _ShowCheckBox = true;
    internal bool ShowCheckBox
    {
        get
        {
            return _ShowCheckBox;
        }
        set
        {
            if (_ShowCheckBox != value)
            {
                _ShowCheckBox = value;
                OnShowCheckBoxChanged();
            }
        }
    }
