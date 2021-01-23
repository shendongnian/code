    private void RemoveItems()
    {
        _newList.Clear();
        foreach (var item in _list)
        {
            item.Process();
            if (!item.NeedsRemoving())
                _newList.Add(item);
        }
        var swap = _list;
        _list = _newList;
        _newList = swap;
    }
