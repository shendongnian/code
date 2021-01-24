    public object Header
    {
        get
        {
            return _header;
        }
        set
        {
            if (_header != value)
            {
                _header = value;
                if (_headerCell != null)
                {
                    _headerCell.Content = _header;
                }
            }
        }
    }
