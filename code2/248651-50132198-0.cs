    public MyColumnCollection Columns
    {
        get
        {
            if (_columns == null)
            {
                _columns = new MyColumnCollection();
                _columns.CollectionChanged += Columns_CollectionChanged;
            }
            return _columns;
        }
    }
    private void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (var item in e.NewItems)
            {
                AddLogicalChild(item);
            }
        }
        if (e.OldItems != null)
        {
            foreach (var item in e.OldItems)
            {
                RemoveLogicalChild(item);
            }
        }
        // not sure about Action == reset
    }
    protected override IEnumerator LogicalChildren
    {
        get
        {
            return _columns == null ? null : _columns.GetEnumerator();
        }
    }
