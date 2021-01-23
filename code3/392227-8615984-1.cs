    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    
        if (_itemsContainer != null)
        {
            _itemsContainer.Tap -= ItemsContainer_Tap;
        }
        _itemsContainer = GetTemplateChild("PART_Items") as ItemsControl;
        if (_itemsContainer != null)
        {
            // When to detach this event for correctly object lifetime?
            _itemsContainer.Tap += ItemsContainer_Tap;
        }
    }
