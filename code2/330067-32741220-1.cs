    public bool _isHide = false;
    
    public bool IsHide
    {
    get { return _isHide; }
    set
        {
        	_isHide = value;
                OnPropertyChanged("IsHide");
        }
