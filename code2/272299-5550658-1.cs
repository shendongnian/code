    protected virtual void OnBindableInScopeItemIdsChanged(ICollection<string> oldBindableInScopeItemIds, ICollection<string> newBindableInScopeItemIds)
    {
        InScopeItemIds.Clear();
        foreach (var itemId in newBindableInScopeItemIds)
        {
            InScopeItemIds.Add(itemId);
        }
    }
