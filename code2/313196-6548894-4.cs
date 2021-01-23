    private ICommand upCommand;
    public ICommand Up
    {
        get { return upCommand ?? (upCommand = new RelayCommand(p => MoveUp())); }
    }
    private void MoveUp()
    {
        var current = (Item)view.CurrentItem;
        var i = current.Index;
        var prev = Items.Single(t => t.Index == (i - 1));
        current.Index = i - 1;
        prev.Index = i;
        view.Refresh(); //you need to refresh the CollectionView to show the changes.
    }
