    private void AddStatus(StatusItem item, bool useDispatcher)
    {
        if (useDispatcher) {
            Dispatcher.BeginInvoke(DispatcherPriority.Send, 
               new ThreadStart(() => AddStatus(item, false)));
            return;
        }
        if (_listStatus.Count > MaxItemsToHoldInList) {
            // maybe you have a more efficient way to do this
            for (int i = 0; i < BlockOfItems; i++ ) _listStatus.RemoveAt(0);
        }
        _listStatus.Add(item);
        
        if (_scrollIntoView) listStatus.ScrollIntoView(item);
    }
