    public void Add(OrderResponse orderResponse)
    {
        this._list.Add(orderResponse);
        CollectionChanged(this,
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                orderResponse, this._list.Count - 1));
    }
