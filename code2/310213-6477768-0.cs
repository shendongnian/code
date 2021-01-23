    private bool _isExpanded;
    public bool IsExpanded
    {
        get { return _isExpanded; }
        set
        {
            _isExpanded = value;
            OnPropertyChange("IsExpanded");
            OnPropertyChange("Content");
        }
    }
    
    public SomeType Content
    {
        get
        {
            if (!_isExpanded)
                return null;
            return LoadContent();
        }
    }
