    public TabViewModel CurrentTabViewModel
    {
        get
        {
            return _tabs.CurrentItem as TabViewModel:
        }
        set
        {
            _tabs.MoveCurrentTo(value);
        }
    }
