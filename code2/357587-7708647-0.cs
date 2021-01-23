    Color _filterColor;
    
    public Color FilterColor
    {
        get
        {
            return _filterColor;
        }
        {
            if (_filterColor != value)
            {
                _filterColor = value;
                RaisePropertyChanged(() => FilterColor);
                
                _OnFilterColorChanged();
            }
    }
    
    void _OnFilterColorChanged()
    {
    	FilterColor = ...
    }
    
    Brush _filterBrush;
    
    public Brush FilterBrush
    {
        get
        {
            return _filterBrush;
        }
        {
            if (_filterBrush != value)
            {
                _filterBrush = value;
                RaisePropertyChanged(() => FilterBrush);
                
                _OnFilterBrushChanged();
            }
    }
    
    void _OnFilterBrushChanged()
    {
    	FilterColor = ...
    }
    
