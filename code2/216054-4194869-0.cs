    private bool _selected;
    
    public bool Selected
    {
        get { return _selected; }
        set
        {
            if (value != _selected)
            {
                _selected = value;
                OnSelectedChanged();
            }
        }
    }
    
    public event EventHandler SelectedChanged;
    
    protected virtual void OnSelectedChanged()
    {
        var handler = SelectedChanged;
        if (handler != null)
            handler(this, EventArgs.Empty);
    }
