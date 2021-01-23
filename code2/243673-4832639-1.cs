    public ICollectionView Tabs
    {
        get 
        {
            if (_view == null)
            {
                _view = CollectionViewSource.GetDefaultView(tabControl.Items);
                _view.Filter = Filter;
            }
            return _view;
        }
    }
    private bool Filter(object arg)
    {
        //arg will be a TabItem, return true if you want it, false if you don't
    }
